using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            string address = Address.Text;
            string emailAddress = EmailAddress.Text;
            string phoneNumber = PhoneNumber.Text;
            string Gender = GenderList.SelectedItem.Value.ToString();
            string country = Country.SelectedValue;
            string username = Username.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;
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

            }
        }
    }
}