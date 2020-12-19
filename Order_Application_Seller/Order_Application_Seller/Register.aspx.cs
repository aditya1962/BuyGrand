using System;
using System.IO;

namespace Order_Application_Seller
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCountries();
            LoadSecretQuestions();
        }

        public void LoadCountries()
        {
            using (StreamReader streamReader = new StreamReader(Server.MapPath("~/Data/countrylistjson.json")))
            {
                string jsonString = streamReader.ReadToEnd();
                dynamic stringDeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);
                foreach (var country in stringDeserialized.names)
                {
                    Country.Items.Add(country.ToString());
                }
            }
        }

        public void LoadSecretQuestions()
        {
            String[] questions = {
                "What is your favorite car?",
                "What is your favorite pet?",
                "What is your uncle's maiden name?",
                "What is your favorite holiday location?"
            };

            foreach (string question in questions)
            {
                SecretQuestion.Items.Add(question);
            }
        }
        

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string firstName = Firstname.Text;
            string lastName = Lastname.Text;
            string address = Address.Text;
            string emailAddress = EmailAddress.Text;
            string phoneNumber = PhoneNumber.Text;
            string gender = GenderList.SelectedItem.Value.ToString();
            string country = Country.SelectedValue;
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
                int adduserLogin = da.insertLogin(username, password, secretQuestion, secretAnswer);
                int adduser = da.insertUser(firstName, lastName, address, emailAddress, phoneNumber, gender, country);

                if (adduserLogin == 1 && adduser == 1)
                {
                    RegisterStatus.Text = "User Registered";
                }
                else
                {
                    RegisterStatus.Text = "Could not register user";
                }
                RegisterStatus.Visible = true;
            }
        }
    }
}