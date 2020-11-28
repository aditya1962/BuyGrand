using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class ViewFeedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string username = Session["username"].ToString();
            string username = "abc";
            LoadFeedbacks(username);
        }

        public void LoadFeedbacks(string username)
        {
            FeedbacksReference.GetFeedbacksSoapClient feedbackReference = new FeedbacksReference.GetFeedbacksSoapClient();
            FeedbacksReference.Feedback[] feedbacks = feedbackReference.ViewFeedbacks(username);

            if(feedbacks.Length > 0)
            {
                string divFeedback = "<table class='feedbacksTable'><tr><th>Username</th><th style='width:55%;'>Feedback</th><th>Submitted Date</th><th></th></tr>";
                for(int i=0; i < feedbacks.Length; i++)
                {
                    divFeedback += "<tr>";
                    divFeedback += "<td>" + feedbacks[i].username + "</td>";
                    divFeedback += "<td>" + feedbacks[i].message + "</td>";
                    divFeedback += "<td>" + feedbacks[i].submittedDate + "</td>";
                    divFeedback += "<td><button id='" + feedbacks[i].id + "' class='btn btn-primary' type='button' data-toggle='modal' data-target='#replyFeedback' onclick=replyID(this.id)>Reply </button></td>";
                    divFeedback += "</tr>";
                }
                divFeedback += "</table>";
                feedbackDiv.InnerHtml = divFeedback;
            }
            else
            {
                NoFeedbacks.Visible = true;
            }
        }
    }
}