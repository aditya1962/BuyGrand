using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Admin.UserControls
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        public string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"]!=null)
            {
                Data.DataAccess da = new Data.DataAccess();
                user = da.getUsersName(Session["username"].ToString());
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}