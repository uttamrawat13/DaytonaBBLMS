using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoreDB;
using System.Data;
using BBDNRESTDemoCSharp;
using BBDN_REST_Demo_CSharp;
namespace DSISLMS_Web
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void RbtnLogin_Click(object sender, EventArgs e)
        {
           
            if (Page.IsValid)
            {
                /*Logincls objLogin = new Logincls();

                string username = string.Empty, password = string.Empty;

                username = Convert.ToString(RTxtUsername.Text);
                password = Convert.ToString(RTxtPassword.Text);
                DataTable dtloginuser = new DataTable();
                dtloginuser = objLogin.CheckLogin(username, password);
                if (dtloginuser.Rows.Count > 0)
                {

                    Session["username"] = dtloginuser.Rows[0]["username"];
                    Session["user_level"] = dtloginuser.Rows[0]["User_level"];
                    Session["CampusId"] = dtloginuser.Rows[0]["CampusId"];
                    Response.Redirect("frmManageRoles.aspx");
                }
                else
                {
                    RlblResult.Text = "Invalid user!";
                } 

                /*string username = string.Empty, password = string.Empty;

                username = Convert.ToString(RTxtUsername.Text).ToLower();
                password = Convert.ToString(RTxtPassword.Text).ToLower();
                if (username == "aaa" && password == "aaa")
                {
                    Session["user_level"] = "99";
                    Response.Redirect("frmblackboard.aspx");
                }
                else
                {
                    RlblResult.Text = "Invalid user!";
                }*/
               
                Response.Redirect("frmblackboard.aspx");
            }
          
        }
       
    }
}