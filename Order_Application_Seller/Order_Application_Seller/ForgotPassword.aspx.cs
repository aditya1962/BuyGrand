using System;

namespace Order_Application_Seller
{
	public partial class ForgotPassword : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void ForgotButton_Click(object sender, EventArgs e)
		{
            string username = Username.Text;
            string password = Password.Text;
            string secretQuestion = SecretQuestion.Text;
            string secretAnswer = SecretAnswer.Text;

            Data.DataAccess da = new Data.DataAccess();
            string name = da.getUsersName(username);

            if (String.IsNullOrEmpty(name))
            {
                ValidationError.Visible = true;
            }
            else
            {
                int updateuserLogin = da.updateLogin(username, password, secretQuestion, secretAnswer);

                if (updateuserLogin == 1)
                {
                    ForgotStatus.Text = "User Registered";
                }
                else
                {
                    ForgotStatus.Text = "Could not register user";
                }
                ForgotStatus.Visible = true;
            }
        }
	}
}