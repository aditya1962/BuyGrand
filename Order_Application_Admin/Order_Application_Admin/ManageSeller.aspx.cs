using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class ManagerSeller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSellerDetails();
        }

        public void LoadSellerDetails()
        {
            string sellerContent = "";
            DataTable sellers = new DataTable();

            string headerRow = "<tr><th style='width:15%;'> Username </th><th style='width:20%;'> Name </th>" +
                                "<th> Country </th><th> Gender </th><th> Email address </th><th> Delete </th>" +
                                "<th>Send Message</th></tr>";
            foreach (DataRow row in sellers.Rows)
            {
                sellerContent += "<tr><td>" + row["username"] + "</td><td>" + row["firstName"] +
                                " " + row["lastName"] + "</td><td>" + row["country"] + "</td><td>" +
                                row["gender"] + "</td><td>" + row["emailAddress"] + "</td><td>" +
                                "<input type='button' class='btn btn-primary' id='delete_" + row["username"] +
                                "' value='Delete'/></td><td><input type='button' class='btn btn-primary' id='"+
                                "sendmessage_"+ row["username"]+"</td></tr>";
            }
            manageSellerHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + sellerContent + "</table>";
        }
    }
}