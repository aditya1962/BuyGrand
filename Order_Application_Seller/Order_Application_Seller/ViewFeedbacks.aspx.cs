using Order_Application_Seller.Data;
using System;

namespace Order_Application_Seller
{
    public partial class ViewFeedbacks : System.Web.UI.Page
    {
        public static int page;
        public static int items;
        public static int startIndex;
        public string username;
        public int feedbacks;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            int[] values = (int[])Enum.GetValues(typeof(Enums.Filters));
            foreach(int value in values)
            {
                FilterDropdown.Items.Add(value.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                username = Session["username"].ToString();
                LoadFeedbacks(username);
            }
        }

        public void Page_LoadComplete(object sender, EventArgs e)
        {
            page = 1;
            if (!String.IsNullOrEmpty(Request["page"]))
            {
                page = Convert.ToInt32(Request["page"]);
            }
            if (!String.IsNullOrEmpty(Request["filter"]))
            {
                FilterDropdown.SelectedValue = Request["filter"];
            }
            items = Convert.ToInt32(FilterDropdown.SelectedValue);
            startIndex = (page - 1) * items;
            LoadFeedbacks(username);
            Pagination();
        }

        public void LoadFeedbacks(string username)
        {
            FeedbacksReference.GetFeedbacksSoapClient feedbackReference = new FeedbacksReference.GetFeedbacksSoapClient();
            FeedbacksReference.Feedback[] feedback = feedbackReference.ViewFeedbacks(username);
            feedbacks = feedback.Length;
            int endindex = startIndex + items;

            if(feedbacks > 0)
            {
                string divFeedback = "<table class='feedbacksTable'><tr><th>Username</th><th style='width:55%;'>Feedback</th><th>Submitted Date</th><th></th></tr>";
                for(int i=startIndex; i < endindex; i++)
                {
                    if(feedbacks == i)
                    {
                        break;
                    }

                    divFeedback += "<tr>";
                    divFeedback += "<td>" + feedback[i].username + "</td>";
                    divFeedback += "<td>" + feedback[i].message + "</td>";
                    divFeedback += "<td>" + feedback[i].submittedDate + "</td>";
                    divFeedback += "<td><button id='" + feedback[i].id + "' class='btn btn-primary' type='button' data-toggle='modal' data-target='#replyFeedback' onclick=replyID(this.id)>Reply </button></td>";
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

        public void Pagination()
        {
            string filter = FilterDropdown.SelectedValue;
            double pages = Math.Ceiling(Convert.ToDouble(feedbacks) / Convert.ToInt32(filter));
            int previous = 1, next = 1;

            if (page == 1)
            {
                previous = 1;
            }
            if (page == pages)
            {
                next = page;
            }
            if (page > 1)
            {
                previous = page - 1;
                next = page + 1;
            }

            string pageHtml = "<td><button class='btn btn-primary previous page-button'><a href='ViewFeedbacks.aspx?page=" + previous +
                "&filter=" + filter + "'> Previous </a></button></td>";
            for (int i = 1; i <= pages; i++)
            {
                pageHtml += "<td><button class='btn btn-primary page-button'><a href='ViewFeedbacks.aspx?page=" + i +
                    "&filter=" + filter + "'>" + i + "</a></button></td>";
            }
            pageHtml += "<td><button class='btn btn-primary next page-button'><a href='ViewFeedbacks.aspx?page=" + next +
                "&filter=" + filter + "'> Next </a></button></td>";
            pagination.InnerHtml = "<table style='margin:auto;'><tr>" + pageHtml + "</tr></table>";
        }
        protected void ValueFiltered(object sender, EventArgs e)
        {
            string value = FilterDropdown.SelectedValue;
            Response.Redirect("ViewFeedbacks.aspx?filter=" + value + "&page=1");
        }
    }
}