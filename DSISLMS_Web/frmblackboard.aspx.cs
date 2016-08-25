using BBDN_REST_Demo_CSharp;
using BBDNRESTDemoCSharp;
using CoreDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace DSISLMS_Web
{
    public partial class frmblackboard1 : System.Web.UI.Page
    {
        BBStudentList objStudentdb = new BBStudentList();
        BBTermList objtermdb = new BBTermList();
        BBCoursesList objcoursedb = new BBCoursesList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserBind();
            }
        }
      

        protected void RTSMainblackboardTab_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            RadTab TabClicked = e.Tab;
            int tabclick=0;
            tabclick = Convert.ToInt32(TabClicked.TabIndex);

            switch (tabclick)
            { 
                case 0:
                    UserBind(); 
                    break;
                case 1:
                    TermBind();
                    break;
                case 2:
                    CoursesBind();
                    break;
                case 3:
                    break;
            }
            RLresult.Text = string.Empty;
        }

        #region "User Bind"
        public void UserBind()
        {
            DataTable dtUsers = new DataTable();
            dtUsers = objStudentdb.GetStudentList();
            Session["dtUsers"] = dtUsers;
            RgvUsers.DataSource = dtUsers;
            RgvUsers.DataBind();
        }
        protected void RgvUsers_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            RLresult.Text = string.Empty;
            this.RgvUsers.MasterTableView.AllowNaturalSort = true;
            this.RgvUsers.MasterTableView.Rebind();
        }

        protected void RgvUsers_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RLresult.Text = string.Empty;
            RgvUsers.DataSource = (DataTable)Session["dtusers"];
        }

        protected void RgvUsers_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "btnpushmodel")
            {
                RLresult.Text = string.Empty;
                GridDataItem ditem = (GridDataItem)e.Item;
                string StudentNo = Convert.ToString(((Label)ditem.FindControl("lbStudentNo")).Text);
                string Username = Convert.ToString(((Label)ditem.FindControl("lbUsername")).Text);
                string last_name = Convert.ToString(((Label)ditem.FindControl("lblast_name")).Text);
                string first_name = Convert.ToString(((Label)ditem.FindControl("lbfirst_name")).Text);
                Label lbOperation = ditem.FindControl("lbOperation") as Label;
                string operation = string.Empty;
                operation = Convert.ToString(lbOperation.Text);
               
                if (operation == "I")
                {
                    ProceedUsers(StudentNo, Username, last_name, first_name, "I");
                }
                else if (operation == "U")
                {
                    ProceedUsers(StudentNo, Username, last_name, first_name, "U");
                }
             }
        }
        protected void RgvUsers_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbOperation = item.FindControl("lbOperation") as Label;
                RadPushButton btnpushmodel = item.FindControl("btnpushmodel") as RadPushButton;
                string operation = string.Empty,btnname=string.Empty;
                operation = Convert.ToString(lbOperation.Text);
                if (operation == "I")
                { 
                    e.Item.Font.Bold=true;
                    btnname="Send to Blackboard";
                }
                else if (operation == "U")
                {
                    e.Item.Font.Bold = false;
                    e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFE491");
                    btnname = "Update to Blackboard";
                }
                btnpushmodel.Text = btnname;
            }
        }
          #region "User send to blackboard"
        private async void ProceedUsers(string StudentNo, string Username, string last_name, string first_name,string action)
                {
                    
                  
                    doUser objuser = new doUser();
                    #region "Set Insert User"
                    User user = new User();
                    user.uuid = string.Empty;
                    user.externalId = StudentNo;
                    user.password = " ";
                    user.userName = Username;
                    user.studentId = StudentNo;
                    //user.educationLevel = string.Empty;
                    //user.gender = string.Empty;
                    //user.birthDate = string.Empty;
                    string[] systemrole = { " " };
                    user.systemRoleIds = systemrole;
                    UserAvailability availables = new UserAvailability();
                    availables.available = "Yes";
                    user.availability = availables;
                    Name name = new Name();
                    name.given = first_name;
                    name.family = last_name;
                    name.middle = last_name;
                    name.other = last_name;
                    name.suffix = last_name;
                    user.name = name;
                    Job job = new Job();
                    //job.title = string.Empty;
                    //job.department = string.Empty;
                    //job.company = string.Empty;
                    user.job = job;
                    Contact contact = new Contact();
                    //contact.homePhone = string.Empty;
                    //contact.mobilePhone = string.Empty;
                    //contact.businessPhone = string.Empty;
                    //contact.businessFax = string.Empty;
                    //contact.email = string.Empty;
                    //contact.webPage = string.Empty;
                    user.contact = contact;
                    Address address = new Address();
                    //address.street1 = string.Empty;
                    //address.street2 = string.Empty;
                    //address.city = string.Empty;
                    //address.state = string.Empty;
                    //address.zipCode = string.Empty;
                    //address.country = string.Empty;
                    user.address = address;
                    UserLocale locale = new UserLocale();
                    //locale.id = string.Empty;
                    //locale.calendar = string.Empty;
                    //locale.firstDayOfWeek = string.Empty;
                    user.locale = locale;
                   #endregion
                 if(action=="I")
                 {
                     
                     #region "create user"
                            User newuser = await objuser.CreateUser(user);
                            string result = string.Empty;
                            result = Convert.ToString(Constants.RESPONSERESULT);
                            if (result == "Fail")
                            {
                              RLresult.Text="Rest API Failed!";
                              RLresult.ForeColor = System.Drawing.Color.Red;
                     
                            }
                            else if (result == "Create")
                            {
                                int userlogResult=0;
                                userlogResult = objStudentdb.InsetUser(newuser, "I");
                                if (userlogResult > 0)
                                {
                                    RLresult.Text = "Student created successfully!";
                                    RLresult.ForeColor = System.Drawing.Color.Green;
                                }
                                UserBind();
                            }
                          #endregion
                 }
                 else if (action == "U")
                 {
                 
                     #region "update user"

                     Constants.USER_ID = user.externalId;
                     User newuser = await objuser.UpdateUser(user);
                     string result = string.Empty;
                     result = Convert.ToString(Constants.RESPONSERESULT);
                     if (result == "Fail")
                     {
                         RLresult.Text = "Rest API failed!";
                         RLresult.ForeColor = System.Drawing.Color.Red;
                     }
                     else if (result == "Update")
                     {
                         int userlogResult = 0;
                         userlogResult = objStudentdb.InsetUser(newuser, "U");
                         if (userlogResult > 0)
                         {
                             RLresult.Text = "Student updated successfully!";
                             RLresult.ForeColor = System.Drawing.Color.Green;
                         }
                         UserBind();
                     }
                    #endregion
                 }
            }
          #endregion
        #region "Slect all item"
        protected void CHBToggleUserAll(object sender, EventArgs e)
        {
            CheckBox headerCheckBox = (sender as CheckBox);
            foreach (GridDataItem dataItem in RgvUsers.MasterTableView.Items)
            {
                (dataItem.FindControl("ItemChkbox") as CheckBox).Checked = headerCheckBox.Checked;
                dataItem.Selected = headerCheckBox.Checked;
            }
        }
        #endregion
        #region "Bulk Insert User"
       /* private async void BulkUserInsert()
        {
            doUser objuser = new doUser();
            DataTable dtUsers = new DataTable();
            dtUsers = objStudentdb.GetALLStudentListInsertBD();
            if (dtUsers.Rows.Count > 0)
            {
                bool newuser = await objuser.BulkCreateUser(dtUsers);
            }
        }*/
        protected void RPBSendalluserBD_Click(object sender, EventArgs e)
            {
               // BulkUserInsert();
                   
          
               /* DataTable dtUsers = new DataTable();
                dtUsers = objStudentdb.GetALLStudentListInsertBD();
                if (dtUsers.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtUsers.Rows)
                    {
                        string StudentNo = string.Empty, Username =string.Empty,last_name = string.Empty,first_name = string.Empty;

                        StudentNo = Convert.ToString(dr["StudentNo"]);
                        Username = Convert.ToString(dr["login_id"]);
                        last_name = Convert.ToString(dr["last_name"]);
                        first_name = Convert.ToString(dr["first_name"]);
                        ProceedUsers(StudentNo, Username, last_name, first_name, "I");
                       
                    }
                }*/
            }

      

        #endregion
        #endregion

        #region "Term Operation"
        public void TermBind()
        {
            DataTable dtTerms = new DataTable();
            dtTerms = objtermdb.GetTermList();
            Session["dtTerms"] = dtTerms;
            RgvTerms.DataSource = (DataTable)Session["dtTerms"];
            RgvTerms.DataBind();
        }
        protected void RgvTerms_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RgvTerms.DataSource = (DataTable)Session["dtTerms"];
        }

        protected void RgvTerms_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "btnpushmodel")
            {
                GridDataItem ditem = (GridDataItem)e.Item;
                string TermID = Convert.ToString(((Label)ditem.FindControl("lbTermID")).Text);
                string termname = Convert.ToString(((Label)ditem.FindControl("lbtermname")).Text);
                string start_date = Convert.ToString(((Label)ditem.FindControl("lbstart_date")).Text);
                string end_date = Convert.ToString(((Label)ditem.FindControl("lbend_date")).Text);
                Label lbOperation = ditem.FindControl("lbOperation") as Label;
                string operation = string.Empty;
                operation = Convert.ToString(lbOperation.Text);
                RLresult.Visible = true;
                RLresult.Text = string.Empty;
                if (operation == "I")
                {
                    ProceedTerm(TermID, termname, start_date, end_date, "I");

                }
                else if (operation == "U")
                {
                    ProceedTerm(TermID, termname, start_date, end_date, "U");
                }
            }
        }
        protected void RgvTerms_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                Label lbOperation = item.FindControl("lbOperation") as Label;
                RadPushButton btnpushmodel = item.FindControl("btnpushmodel") as RadPushButton;
                string operation = string.Empty, btnname = string.Empty;
                operation = Convert.ToString(lbOperation.Text);
                if (operation == "I")
                {
                    e.Item.Font.Bold = true;
                    btnname = "Send to Blackboard";
                }
                else if (operation == "U")
                {
                    e.Item.Font.Bold = false;
                    e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFE491");
                    btnname = "Update to Blackboard";
                }
                btnpushmodel.Text = btnname;
            }
        }
        protected void RgvTerms_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            this.RgvTerms.MasterTableView.AllowNaturalSort = true;
            this.RgvTerms.MasterTableView.Rebind();
        }
        #region "Term send to blackboard"

        private async void ProceedTerm(string TermID, string termname, string start_date, string end_date, string action)
        {
            doTerm objterm = new doTerm();
            #region "Set Insert Term"
            Term term = new Term();
            term.name = termname;
            term.description = termname;
            term.externalId = TermID;
            Availability available = new Availability();
            available.available = "Yes";
            Duration duration = new Duration();
            duration.type = "DateRange";
            duration.start = start_date;
            duration.end = end_date;
            available.duration = duration;
            term.availability = available;
            #endregion
               
            if (action == "I")
            {
                #region "create Term"
          
                Term newterm = await objterm.CreateTerm(term);
                string result = string.Empty;
                result = Convert.ToString(Constants.RESPONSERESULT);
                if (result == "Fail")
                {
                    RLresult.Text = "Rest API failed!";
                    RLresult.ForeColor = System.Drawing.Color.Red;

                }
                else if (result == "Create")
                {
 
                     int termlogResult = 0;
                     termlogResult = objtermdb.InsetTerm(newterm, "I");
                     if (termlogResult > 0)
                     {
                         RLresult.Text = "Term created successfully!";
                         RLresult.ForeColor = System.Drawing.Color.Green;
                         TermBind();
                     }
                }
                
                #endregion
            }
            else if (action == "U")
            {

                #region "update user"

                    Constants.TERM_ID = term.externalId;
                    Term newterm = await objterm.UpdateTerm(term);
                    string result = string.Empty;
                    result = Convert.ToString(Constants.RESPONSERESULT);
                    if (result == "Fail")
                    {
                        RLresult.Text = "Rest API failed!";
                        RLresult.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (result == "Update")
                    {
                        int termlogResult = 0;
                        termlogResult = objtermdb.InsetTerm(newterm, "U");
                        if (termlogResult > 0)
                        {
                            RLresult.Text = "Term updated successfully!";
                            RLresult.ForeColor = System.Drawing.Color.Green;
                            TermBind();
                        }
                        }
                #endregion

            }
        }
        #endregion

        #endregion
        #region "Courses Operation"
        public void CoursesBind()
            {
                DataTable dtCourses = new DataTable();
                dtCourses = objcoursedb.GetCoursesList();
                Session["dtCourses"] = dtCourses;
                RgvCourse.DataSource = (DataTable)Session["dtCourses"];
                RgvCourse.DataBind();
            }
        
            protected void RgvCourse_ItemCommand(object sender, GridCommandEventArgs e)
            {
                if (e.CommandName == "btnpushmodel")
                {
                    GridDataItem ditem = (GridDataItem)e.Item;

                    string CourseOfferingNo = Convert.ToString(((Label)ditem.FindControl("lbCourseOfferingNo")).Text);
                   // string course_id = Convert.ToString(((Label)ditem.FindControl("lbcourse_id")).Text);
                    string short_name = Convert.ToString(((Label)ditem.FindControl("lbshort_name")).Text);
                    string long_name = Convert.ToString(((Label)ditem.FindControl("lblong_name")).Text);
                    string term_id = Convert.ToString(((Label)ditem.FindControl("lbterm_id")).Text);
                    Label lbOperation = ditem.FindControl("lbOperation") as Label;
                    string operation = string.Empty;
                    operation = Convert.ToString(lbOperation.Text);
                    RLresult.Visible = true;
                    RLresult.Text = string.Empty;
                    if (operation == "I")
                    {
                        ProceedCourses(CourseOfferingNo, CourseOfferingNo, short_name, long_name, term_id, "I");

                    }
                    else if (operation == "U")
                    {
                        ProceedCourses(CourseOfferingNo, CourseOfferingNo, short_name, long_name, term_id, "U");
                    }
                }
            }

            protected void RgvCourse_ItemDataBound(object sender, GridItemEventArgs e)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    Label lbOperation = item.FindControl("lbOperation") as Label;
                    RadPushButton btnpushmodel = item.FindControl("btnpushmodel") as RadPushButton;
                    string operation = string.Empty, btnname = string.Empty;
                    operation = Convert.ToString(lbOperation.Text);
                    if (operation == "I")
                    {
                        e.Item.Font.Bold = true;
                        btnname = "Send to Blackboard";
                    }
                    else if (operation == "U")
                    {
                        e.Item.Font.Bold = false;
                        e.Item.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFE491");
                        btnname = "Update to Blackboard";
                    }
                    btnpushmodel.Text = btnname;
                }
            }
            protected void RgvCourse_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
            {
                RgvCourse.DataSource = (DataTable)Session["dtCourses"];
            }

            protected void RgvCourse_SortCommand(object sender, GridSortCommandEventArgs e)
            {
                this.RgvCourse.MasterTableView.AllowNaturalSort = true;
                this.RgvCourse.MasterTableView.Rebind();

            }
            #region "Courses send to blackboard"
                
            private async void ProceedCourses(string CourseOfferingNo,string course_id, string short_name, string long_name, string term_id, string action)
            {
                doCourse objCourse = new doCourse();
                #region "Set Insert Course"
                Course course = new Course();
                course.courseId = course_id;
                course.description = long_name;
                course.name = short_name;
                course.externalId = CourseOfferingNo;
                if(term_id != string.Empty)
                { 
                course.termId = term_id;
                }
                #endregion

                if (action == "I")
                {
                    #region "create Term"

                    Course newcourse = await objCourse.CreateCourse(course);
                    string result = string.Empty;
                    result = Convert.ToString(Constants.RESPONSERESULT);
                    if (result == "Fail")
                    {
                        RLresult.Text = "Rest API failed!";
                        RLresult.ForeColor = System.Drawing.Color.Red;

                    }
                    else if (result == "Create")
                    {

                        int courselogResult = 0;
                        courselogResult = objcoursedb.InsetUser(newcourse, "I");
                        if (courselogResult > 0)
                        {
                            RLresult.Text = "Course created successfully!";
                            RLresult.ForeColor = System.Drawing.Color.Green;
                            CoursesBind();
                        }
                    }

                    #endregion
                }
                else if (action == "U")
                {

                    #region "update user"

                    Constants.COURSE_ID = course.externalId;
                    course.name="U"+short_name;
                    Course newcourse = await objCourse.UpdateCourse(course);
                    string result = string.Empty;
                    result = Convert.ToString(Constants.RESPONSERESULT);
                    if (result == "Fail")
                    {
                        RLresult.Text = "Rest API failed!";
                        RLresult.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (result == "Update")
                    {
                        int courselogResult = 0;
                        courselogResult = objcoursedb.InsetUser(newcourse, "U");
                        if (courselogResult > 0)
                        {
                            RLresult.Text = "Course Update successfully!";
                            RLresult.ForeColor = System.Drawing.Color.Green;
                            CoursesBind();
                        }
                    }
                    #endregion

                }
            }
            #endregion

          
      
        #endregion

       


    }
}