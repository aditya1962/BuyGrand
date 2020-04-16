using System;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace Order_Application_Admin
{
    public partial class ManagerSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadSellerDetails();
            }
        }

        public void LoadSellerDetails()
        {
            string sellerContent = "";
            ManageSellerReference.ManageSellerSoapClient manageSellers = new ManageSellerReference.ManageSellerSoapClient();
            DataTable sellers = manageSellers.manageSellers();

            string headerRow = "<tr><th style='width:15%;'> Username </th><th style='width:20%;'> Name </th>" +
                                "<th> Country </th><th> Gender </th><th> Email address </th><th> Delete </th>" +
                                "<th>Send Message</th></tr>";
            int sellerCount = sellers.Rows.Count;
            if (sellerCount > 0)
            {
                foreach (DataRow row in sellers.Rows)
                {
                    sellerContent += "<tr><td>" + row["username"] + "</td><td>" + row["firstName"] +
                                " " + row["lastName"] + "</td><td>" + row["country"] + "</td><td>" +
                                row["gender"] + "</td><td>" + row["emailAddress"] + "</td><td>" +
                                "<button type='button' class='btn btn-primary' id='delete_" + row["username"] +
                                "' data-toggle='modal' data-target='#deleteModal' onclick=deleteClick(this.id)>Delete</button></td><td><button type='button' class='btn btn-primary' id='" +
                                "sendmessage_" + row["username"] + "' onclick=sendMessage(this.id) data-toggle='modal' " +
                                "data-target='#sendMessageModal'>Send Message</button></td></tr>";
                }
            }
            else
            {
                sellerContent += "<tr><td colspan='7' style='font-size:15px;'> No sellers found </td></tr>";
            }
            manageSellerHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + sellerContent + "</table>";
        }

        public void Delete_Click(object sender,EventArgs e)
        {
            string usernameDelete = deleteValue.Value;
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;

            if(username=="")
            {
                DeleteUsernameBlank.Visible = true;
            }
            else if(password=="")
            {
                DeletePasswordBlank.Visible = true;
            }
            else
            {
                Data.DataAccess dataAccess = new Data.DataAccess();
                int validate = dataAccess.validateUser(username, password);
                //currently set validate to 1
                validate = 1;
                if(validate==1)
                {
                    ManageSellerReference.ManageSellerSoapClient manageSellerSoap = new ManageSellerReference.ManageSellerSoapClient();
                    int rowsDeleted = manageSellerSoap.delete(usernameDelete);
                    if(rowsDeleted > 0)
                    {
                        deleteSuccess.Text = "Seller deleted successfully";
                        deleteSuccess.Visible = true;
                    }
                    else
                    {
                        deleteSuccess.Text = "Could not delete seller";
                        deleteSuccess.Visible = true;
                    }
                }
                else
                {
                    DeleteAccountInvalid.Visible = true;
                }
            }
        }

        public void Send_Click(object sender, EventArgs e)
        {
            string user = sendMessageVal.Value;
            string username = Username.Text;
            string password = Password.Text;
            string message = Message.Text;
            string subject = Subject.Text;
            string emailUsername = EmailUsername.Text;
            string emailPassword = EmailPassword.Text;

            if(username=="")
            {
                UsernameBlank.Visible = true;
            }
            else if(password=="")
            {
                PasswordBlank.Visible = true;
            }
            else if(message=="")
            {
                MessageBlank.Visible = true;
            }
            else if(subject=="")
            {
                SubjectBlank.Visible = true;
            }
            else if(emailUsername == "")
            {
                EmailUsernameBlank.Visible = true;
            }
            else if(emailPassword=="")
            {
                EmailPasswordBlank.Visible = true;
            }
            else
            {
                Data.DataAccess validate = new Data.DataAccess();
                int valid = validate.validateUser(username, password);
                //currently set valid to 1
                valid = 1;
                if(valid==1)
                {
                    string[] emailValues = {user, subject, emailUsername, emailPassword, message};
                    Email email = new Email();
                    email.sendEmail(emailValues);
                }
                else
                {
                    AccountInvalid.Visible = true;
                }
            }
        }
    }
}