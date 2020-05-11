using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class Feedbacks : System.Web.UI.Page
    {
        int page, filter;
        DataTable feedbacksData;

        protected void Page_PreLoad(object sender,EventArgs e)
        {
            if(!IsPostBack)
            {
                int[] filter = (int[])Enum.GetValues(typeof(Data.Enums.FilterCategories));
                foreach(int val in filter)
                {
                    FilterValues.Items.Add(new ListItem(val.ToString()));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            page = 1;
            if(!String.IsNullOrEmpty(Request["page"]))
            {
                page = Convert.ToInt32(Request["page"]);
            }
            if(!String.IsNullOrEmpty(Request["filter"]))
            {
                FilterValues.SelectedValue = Request["filter"];
            }
            filter = Convert.ToInt32(FilterValues.SelectedValue);

            feedbacksHtml.InnerHtml = "";
            LoadFeedbacks();
            Pagination();
        }

        public void LoadFeedbacks()
        {
            string feedbackContent = "";

            FeedbackReference.FeedbacksSoapClient feedbackClient = new FeedbackReference.FeedbacksSoapClient();

            feedbacksData = feedbackClient.viewFeedbacks();

            string headerRow = "<tr><th style='width:15%;'> Feedback ID </th><th style='width:25%;'> Feedback </th><th style='width:10%;'> Username </th>" +
                                "<th style='width:10%;'> Submitted Date </th><th style='width:15%;'>Role</th><th style='width:15%;'>&nbsp;</th></tr>";
            int feedbackCount = feedbacksData.Rows.Count;
            if (feedbackCount > 0)
            {
                foreach (DataRow row in feedbacksData.Rows)
                {
                    feedbackContent += "<tr><td>" + row["feedbackID"] + "</td><td>" + row["message"] +
                                "</td><td>" + row["username"] + "</td><td>" + row["submittedDate"] + "</td><td>" +
                                row["role"] + "</td><td><button type='button' class='btn btn-primary' id='send_" + row["feedbackID"] +
                                "' data-toggle='modal' data-target='#feedbackModal' onclick=sendFeedback(this.id)>Send Feedback</button></td></tr>";
                }
            }
            else
            {
                feedbackContent += "<tr><td colspan='6' style='font-size:15px;'> No feedbacks found </td></tr>";
            }
            feedbacksHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + feedbackContent + "</table>";
        }

        public void Feedback_Click(object sender, EventArgs e)
        {

            string feedbackID = feedbackUser.Value;
            string feedbackTxt = feedback.Text;
            string username = Username.Text;
            string password = Password.Text;

            Data.DataAccess da = new Data.DataAccess();
            int validate = da.validateUser(username, password);
            //set validate currently to 1
            validate = 1;
            if (validate == 1)
            {
                FeedbackReference.FeedbacksSoapClient feedbackClient = new FeedbackReference.FeedbacksSoapClient();

                string usernameFeedback = feedbackClient.getUsername(feedbackID);
                int rows = feedbackClient.addAdminFeedback(usernameFeedback, feedbackTxt);
                if (rows > 0)
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

        public void Pagination()
        {
            string paginationCont = "";
            int previous = 1;
            int next = 1;

            double pages = Math.Ceiling((double)feedbacksData.Rows.Count / filter);
            if(pages > 1)
            {
                previous = page - 1;
                next = page + 1;
            }
            else if(page==pages)
            {
                next = page;
            }

            paginationCont += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='Feedbacks.aspx?page=" +
                    previous + "&filter=" + filter + "'>Previous</a></button></td>";

            for (int i = 1; i <= pages; i++)
            {
                paginationCont += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='Feedbacks.aspx?page=" +
                                    i + "&filter=" + filter + "'>" + i + "</a></button></td>";
            }

            paginationCont += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='Feedbacks.aspx?page=" +
                    next + "&filter=" + filter + "'>Next</a></button></td>";

            paginationHtml.InnerHtml = "<table style='margin:auto;'><tr>" + paginationCont + "</tr></table>"; 
        }
    }
}