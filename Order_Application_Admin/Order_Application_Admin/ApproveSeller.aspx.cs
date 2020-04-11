using System;
using System.Data;

namespace Order_Application_Admin
{
    public partial class ApproveSeller : System.Web.UI.Page
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

            SellerReference.ApproveSellerSoapClient seller = new SellerReference.ApproveSellerSoapClient();

            DataTable sellers = seller.approveSellers();

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

        public void Approve_Click(object sender,EventArgs e)
        {

        }
    }
}