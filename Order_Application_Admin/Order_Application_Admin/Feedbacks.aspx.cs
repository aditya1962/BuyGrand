using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class Feedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFeedbacks();
        }

        public void LoadFeedbacks()
        {
            string feedbackContent = "";
            DataTable feedbacks = new DataTable();

            string headerRow = "<tr><th style='width:15%;'> Feedback ID </th><th style='width:25%;'> Feedback </th><th style='width:10%;'> Username </th>" +
                                "<th style='width:10%;'> Submitted Date </th><th style='width:15%;'>Role</th><th style='width:15%;'>&nbsp;</th></tr>";
            int feedbackCount = feedbacks.Rows.Count;
            if (feedbackCount > 0)
            {
                foreach (DataRow row in feedbacks.Rows)
                {
                    feedbackContent += "<tr><td>" + row["feedbackID"] + "</td><td>" + row["feedback"] +
                                "<td></td>" + row["username"] + "</td><td>" + row["submittedDates"] + "</td><td>" +
                                row["role"]+"<input type='button' class='btn btn-primary' id='send_" + row["feedbackID"] +
                                "' value='Send Feedback'/></td><td></tr>";
                }
            }
            else
            {
                feedbackContent += "<tr><td colspan='6' style='font-size:15px;'> No feedbacks found </td></tr>";
            }
            feedbacksHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + feedbackContent + "</table>";
        }
    }
}