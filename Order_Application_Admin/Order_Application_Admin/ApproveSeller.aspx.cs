using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class ApproveSeller : System.Web.UI.Page
    {
        int filter, page;
        DataTable sellers;
        public enum State
        {
            Validated,
            Unvalidated,
            Invalidated
        }

        public State UserValidated { get; set; }
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (Session["ValidateApprove"] != null && Session["ValidateApprove"].ToString().Equals("validated"))
            {
                ValidateAccount.Visible = false;
                FilterRow.Visible = true;
                this.UserValidated = State.Validated;
                int[] filters = (int[])Enum.GetValues(typeof(Data.Enums.FilterCategories));
                foreach (int filter in filters)
                {
                    FilterVal.Items.Add(new ListItem(filter.ToString()));
                }
            }
            else
            {
                this.UserValidated = State.Unvalidated;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            State validatedState = this.UserValidated;
            if (validatedState.Equals(State.Validated))
            {
                page = 1;
                if (!String.IsNullOrEmpty(Request["page"]))
                {
                    page = Convert.ToInt32(Request["page"]);
                }
                if (!String.IsNullOrEmpty(Request["filter"]))
                {
                    FilterVal.SelectedValue = Request["filter"];
                }
                filter = Convert.ToInt32(FilterVal.SelectedValue);
                LoadSellerDetails();
                Pagination();
            }
        }

        public void LoadSellerDetails()
        {
            string sellerContent = "";

            SellerReference.ApproveSellerSoapClient seller = new SellerReference.ApproveSellerSoapClient();

            int startIndex = (page - 1) * filter;
            sellers = seller.approveSellers(startIndex,filter);

            string headerRow = "<tr><th style='width:15%;'> Username </th><th style='width:20%;'> Name </th>" +
                                "<th> Country </th><th> Gender </th><th> Email address </th><th> Enable </th>" +
                                "</tr>";
            int sellerCount = sellers.Rows.Count;
            if (sellerCount > 0)
            {
                foreach (DataRow row in sellers.Rows)
                {
                    sellerContent += "<tr><td>" + row["username"] + "</td><td>" + row["firstName"] +
                                " " + row["lastName"] + "</td><td>" + row["country"] + "</td><td>" +
                                row["gender"] + "</td><td>" + row["emailAddress"] + "</td><td>" +
                                "<button type='button' class='btn btn-primary' id='" + row["username"] +
                                "' onclick=approveClick(this.id)> Approve </button></td></tr>";
                }
            }
            else
            {
                sellerContent += "<tr><td colspan='6' style='font-size:15px;'> No sellers found</td></tr>";
            }
            approveSellerHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + sellerContent + "</table>";
        }

        public void Pagination()
        {
            string paginationContent = "";
            int previous = 1;
            int next = 1;

            double pages = Math.Ceiling((double)sellers.Rows.Count / filter);
            if (pages > 0)
            {
                if (pages > 1)
                {
                    previous = page - 1;
                    next = page + 1;
                }
                if(page==1)
                {
                    previous = 1;
                }
                if (page == pages)
                {
                    next = page;
                }
                paginationContent += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='" +
                                        "ApproveSeller.aspx?page=" + previous + "&filter=" + filter + "'>" +
                                        "Previous</a></button></td>";
                for (int i = 1; i <= pages; i++)
                {
                    paginationContent += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='" +
                                         "ApproveSeller.aspx?page=" + i + "&filter=" + filter + "'>" + i + "</a>" +
                                         "</button></td>";
                }
                paginationContent += "<td><button class='btn btn-primary' style='margin:0% 3%;'><a href='" +
                                        "ApproveSeller.aspx?page=" + next + "&filter=" + filter + "'>" +
                                        "Next</a></button></td>";
                paginationHtml.InnerHtml = "<table style='margin:auto;'><tr>" + paginationContent + "</tr></table>";
            }
        }

        protected void FilterVal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = FilterVal.SelectedValue;
            Response.Redirect("ApproveSeller.aspx?page=1&filter=" + filter);
        }

        public void Validate_Click(object sender, EventArgs e)
        {
            string username = Username.Text;
            string password = Password.Text;

            Data.DataAccess da = new Data.DataAccess();
            int validate = da.validateUser(username, password);
            //currently set validate to 1
            validate = 1;
            if (validate == 1)
            {
                this.UserValidated = State.Validated;
                Session["ValidateApprove"] = "validated";
                Response.Redirect("ApproveSeller.aspx");
            }
            else
            {
                this.UserValidated = State.Invalidated;
                ValidateUser.Text = "Incorrect username/password";
                ValidateUser.Visible = true;
            }
        }
    }
}