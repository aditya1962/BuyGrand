using System;
using System.Collections.Generic;
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
            Session["username"] = "admin";
            //Get the name of the user from the web service
            user = Session["username"].ToString();
        }
    }
}