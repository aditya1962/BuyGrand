using System;
using System.Data;

namespace Order_Application_Admin
{
    public partial class Feedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadFeedbacks();
            }
        }

        public void LoadFeedbacks()
        {
            string feedbackContent = "";

            FeedbackReference.FeedbacksSoapClient feedbackClient = new FeedbackReference.FeedbacksSoapClient();

            DataTable feedbacks = feedbackClient.viewFeedbacks();

            string headerRow = "<tr><th style='width:15%;'> Feedback ID </th><th style='width:25%;'> Feedback </th><th style='width:10%;'> Username </th>" +
                                "<th style='width:10%;'> Submitted Date </th><th style='width:15%;'>Role</th><th style='width:15%;'>&nbsp;</th></tr>";
            int feedbackCount = feedbacks.Rows.Count;
            if (feedbackCount > 0)
            {
                foreach (DataRow row in feedbacks.Rows)
                {
                    feedbackContent += "<tr><td>" + row["feedbackID"] + "</td><td>" + row["message"] +
                                "</td><td>" + row["username"] + "</td><td>" + row["submittedDate"] + "</td><td>" +
                                row["role"]+ "</td><td><button type='button' class='btn btn-primary' id='send_" + row["feedbackID"] +
                                "' data-toggle='modal' data-target='#feedbackModal' onclick=sendFeedback(this.id)>Send Feedback</button></td></tr>";
                }
            }
            else
            {
                feedbackContent += "<tr><td colspan='6' style='font-size:15px;'> No feedbacks found </td></tr>";
            }
            feedbacksHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + feedbackContent + "</table>";
        }

        public void Feedback_Click(object sender,EventArgs e)
        {

            string feedbackID = feedbackUser.Value;
            string feedbackTxt = feedback.Text;
            string username = Username.Text;
            string password = Password.Text;

            if(feedbackTxt=="")
            {
                FeedbackBlank.Visible = true;
            }
            else if(username=="")
            {
                UsernameBlank.Visible = true;
            }
            else if(password=="")
            {
                PasswordBlank.Visible = true;
            }
            else
            {
                Data.DataAccess da = new Data.DataAccess();
                int validate = da.validateUser(username, password);
                //set validate currently to 1
                validate = 1;
                if(validate == 1)
                {
                    FeedbackReference.FeedbacksSoapClient feedbackClient = new FeedbackReference.FeedbacksSoapClient();

                    string usernameFeedback = feedbackClient.getUsername(feedbackID);
                    int rows = feedbackClient.addAdminFeedback(usernameFeedback, feedbackTxt);
                    if(rows > 0)
                    {
                        FeedbackAdded.Text = "Feedback added successfully";
                        FeedbackAdded.Visible = true;
                    }
                    else
                    {
                        FeedbackAdded.Text = "Could not add feedback";
                        FeedbackAdded.Visible = true;
                    }
                }  
                else
                {
                    AccountInvalid.Visible = true;
                }
            }           
        }
    }
}