using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CoreDB;
using Telerik.Web.UI;
namespace DSISLMS_Web
{
    public partial class DSISLMS_Main : System.Web.UI.MasterPage
    {
        internal class SiteDataItem
        {
            private string _text;
            private string _url;
            private int _id;
            private int? _parentId;
            private string _MobileView;
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            public string Url
            {
                get { return _url; }
                set { _url = value; }
            }

            public int ID
            {
                get { return _id; }
                set { _id = value; }
            }

            public int? ParentID
            {
                get { return _parentId; }
                set { _parentId = value; }
            }
            public string MobileView
            {
                get { return _MobileView; }
                set { _MobileView = value; }
            }
            public SiteDataItem(int id, int? parentId, string text, string url, string MobileView)
            {
                _id = id;
                _parentId = parentId;
                _text = text;
                _url = url;
                _MobileView = MobileView;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = string.Empty;
                username = Convert.ToString(Session["username"]); 

                LBloginuser.Text = username;
                #region "For all User Menu Bind"
                  UserMenuBind();
                /* List<SiteDataItem> siteData = new List<SiteDataItem>();
                siteData.Add(new SiteDataItem(1, 0, "Blackboard", "frmblackboard.aspx",""));
                siteData.Add(new SiteDataItem(2, 0, "Schedule", "frmschedule.aspx", ""));
                siteData.Add(new SiteDataItem(3, 0, "Logout", "", "frmLogin.aspx"));

                RMenuMain.DataTextField = "Text";
                RMenuMain.DataNavigateUrlField = "Url";
                RMenuMain.DataFieldID = "ID";
                RMenuMain.DataValueField = "ID";
                RMenuMain.DataFieldParentID = "ParentID";
                RMenuMain.DataSource = (List<SiteDataItem>)siteData;
                RMenuMain.DataBind(); */

                # endregion
            }
        }

        private void UserMenuBind()
        {
           /* MeanMenucls objMenu = new MeanMenucls();
            DataTable Menudt = new DataTable();
            string  user_level = string.Empty;
            user_level = Convert.ToString(Session["user_level"]);
            Menudt = objMenu.UserMenuBind(user_level);
            if (Menudt.Rows.Count > 0)
            {


                List<SiteDataItem> siteData = new List<SiteDataItem>();

                DataRow[] MenuparentRow = Menudt.Select("ParentID='0'");


                foreach (DataRow l_parentRow in MenuparentRow)
                {

                    string text = string.Empty, url = string.Empty, id = string.Empty, parentId = string.Empty, MobileView = string.Empty;

                    text = Convert.ToString(l_parentRow["Menu"]);
                    id = Convert.ToString(l_parentRow["Menu_ID"]);
                    url = Convert.ToString(l_parentRow["link"]);
                    parentId = Convert.ToString(l_parentRow["parentId"]);
                    MobileView = Convert.ToString(l_parentRow["MobileView"]);
                    if (MobileView == "1")
                    {
                        MobileView = "additionalColumn";
                    }
                    else
                    {
                        MobileView = string.Empty;
                    }
                    if (parentId == "0")
                    {
                        siteData.Add(new SiteDataItem(Convert.ToInt32(id), null, text, url, MobileView));
                    }
                    else
                    {
                        siteData.Add(new SiteDataItem(Convert.ToInt32(id), Convert.ToInt32(parentId), text, url, MobileView));

                    }


                    DataRow[] MenuChildRow = Menudt.Select("ParentID='" + id + "' ");
                    if (MenuChildRow.Length > 0)
                    {
                        foreach (DataRow l_ChildRow in MenuChildRow)
                        {
                            text = string.Empty;
                            url = string.Empty;
                            id = string.Empty;
                            parentId = string.Empty;
                            MobileView = string.Empty;
                            text = Convert.ToString(l_ChildRow["Menu"]);
                            id = Convert.ToString(l_ChildRow["Menu_ID"]);
                            url = Convert.ToString(l_ChildRow["link"]);
                            parentId = Convert.ToString(l_ChildRow["parentId"]);
                            MobileView = Convert.ToString(l_ChildRow["MobileView"]);
                            if (MobileView == "1")
                            {
                                MobileView = "additionalColumn";
                            }
                            else
                            {
                                MobileView = string.Empty;
                            }
                            if (parentId == "0")
                            {
                                siteData.Add(new SiteDataItem(Convert.ToInt32(id), null, text, url, MobileView));
                            }
                            else
                            {
                                siteData.Add(new SiteDataItem(Convert.ToInt32(id), Convert.ToInt32(parentId), text, url, MobileView));

                            }
                        }
                    }

                    
                  
                        RMenuMain.DataTextField = "Text";
                        RMenuMain.DataNavigateUrlField = "Url";
                        RMenuMain.DataFieldID = "ID";
                        RMenuMain.DataValueField = "ID";
                        RMenuMain.DataFieldParentID = "ParentID";
                        RMenuMain.DataSource = (List<SiteDataItem>)siteData;
                        RMenuMain.DataBind();

 
                }


                 

            }*/
        }

        protected void RMenuMain_ItemClick(object sender, RadMenuEventArgs e)
        {

        }
    }
}