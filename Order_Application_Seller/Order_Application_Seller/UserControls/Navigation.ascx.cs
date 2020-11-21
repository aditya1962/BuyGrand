using System;

namespace Order_Application_Seller.UserControls
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        public string user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Data.DataAccess da = new Data.DataAccess();
                user = da.getUsersName(Session["username"].ToString());
            }
            else
            {
                //Response.Redirect("~/Login.aspx");
            }
        }
    }
}