using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string usernameText = Username.Text;
            string passwordText = Password.Text;

            Data.DataAccess da = new Data.DataAccess();
            string passwordHashed = da.Hash(passwordText);
            int validate = da.validateUser(usernameText, passwordHashed);
            validate = 1;
            if (validate == 1)
            {
                Session["username"] = usernameText;

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                    usernameText, DateTime.Now, DateTime.Now.AddMinutes(30), false, "Data for login",
                    FormsAuthentication.FormsCookiePath);
                string ticketEncrypt = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncrypt));
                Response.Redirect("Index.aspx");
            }
            else
            {
                ValidationError.Visible = true;
            }
        }
    }
}
