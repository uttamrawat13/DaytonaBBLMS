using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DSISLMS_Web
{
    public partial class frmschedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Scheduledummydata> dummydata()
        {
            List<Scheduledummydata> dummydata = new List<Scheduledummydata>();
            dummydata.Add(new Scheduledummydata("User data insert","Daily"));
            dummydata.Add(new Scheduledummydata("Category data insert", "Weekly"));
            dummydata.Add(new Scheduledummydata("Terms data insert", "Monthly"));
            dummydata.Add(new Scheduledummydata("Enrollment data insert", "yearly")); //daily weekly monthly yearly
            return dummydata;
        }

        public class Scheduledummydata
        {
            string _Scheduletitle, _Repeat;

            public string Scheduletitle
            {
                get { return _Scheduletitle; }
                set { _Scheduletitle = value; }
            }
            public string Repeat
            {
                get { return _Repeat; }
                set { _Repeat = value; }
            }
            public Scheduledummydata(string Scheduletitle, string Repeat)
            {
                _Scheduletitle = Scheduletitle;
                _Repeat = Repeat;
            }
        }

        protected void RgvSMSConfig_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RgvSMSConfig.DataSource = dummydata();
        }

        protected void RgvSMSConfig_SortCommand(object sender, Telerik.Web.UI.GridSortCommandEventArgs e)
        {
            this.RgvSMSConfig.MasterTableView.AllowNaturalSort = true;
            this.RgvSMSConfig.MasterTableView.Rebind();
        }

        protected void RgvSMSConfig_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {

        }
    }
}