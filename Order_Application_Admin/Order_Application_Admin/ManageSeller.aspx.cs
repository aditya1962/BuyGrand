using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class ManagerSeller : System.Web.UI.Page
    {
        public static DataTable sellers;
        public static int sellerCount;
        public static int page;
        public static int items;
        public static int startIndex;
        ManageSellerReference.ManageSellerSoapClient manageSellers;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int[] values = (int[])Enum.GetValues(typeof(Data.Enums.FilterCategories));
                foreach (int value in values)
                {
                    FilterValues.Items.Add(new ListItem(value.ToString()));
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            manageSellerHtml.InnerHtml = "";
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
                FilterValues.SelectedValue = Request["filter"];
            }
            items = Convert.ToInt32(FilterValues.SelectedValue);
            startIndex = (page - 1) * items;
            LoadSellerDetails();
            Pagination();
        }

        public void LoadSellerDetails()
        {
            string sellerContent = "";
            string headerRow = "<tr><th style='width:15%;'> Username </th><th style='width:20%;'> Name </th>" +
                                "<th> Country </th><th> Gender </th><th> Email address </th><th> Delete </th>" +
                                "<th>Send Message</th></tr>";
            manageSellers = new ManageSellerReference.ManageSellerSoapClient();
            sellers = manageSellers.manageSellers(startIndex, items);
            sellerCount = sellers.Rows.Count;
            if (sellerCount > 0)
            { 
                for (int i = 0; i < items; i++)
                {
                    if (i >= sellerCount)
                    {
                        break;
                    }
                    else
                    {
                        DataRow row = sellers.Rows[i];
                        sellerContent += "<tr><td>" + row["username"] + "</td><td>" + row["firstName"] +
                                    " " + row["lastName"] + "</td><td>" + row["country"] + "</td><td>" +
                                    row["gender"] + "</td><td>" + row["emailAddress"] + "</td><td>" +
                                    "<button type='button' class='btn btn-primary' id='delete_" + row["username"] +
                                    "' data-toggle='modal' data-target='#deleteModal' onclick=deleteClick(this.id)>Delete</button></td><td><button type='button' class='btn btn-primary' id='" +
                                    "sendmessage_" + row["username"] + "' onclick=sendMessage(this.id) data-toggle='modal' " +
                                    "data-target='#sendMessageModal'>Send Message</button></td></tr>";
                    }
                }
            }
            else
            {
                sellerContent += "<tr><td colspan='7' style='font-size:15px;'> No sellers found </td></tr>";
            }
            manageSellerHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + sellerContent + "</table>";
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            string usernameDelete = deleteValue.Value;
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;

            Data.DataAccess dataAccess = new Data.DataAccess();
            int validate = dataAccess.validateUser(username, password);
            //currently set validate to 1
            validate = 1;
            if (validate == 1)
            {
                ManageSellerReference.ManageSellerSoapClient manageSellerSoap = new ManageSellerReference.ManageSellerSoapClient();
                int rowsDeleted = manageSellerSoap.delete(usernameDelete);
                if (rowsDeleted > 0)
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

        public void Send_Click(object sender, EventArgs e)
        {
            string user = sendMessageVal.Value;
            string username = Username.Text;
            string password = Password.Text;
            string message = Message.Text;
            string subject = Subject.Text;
            string emailUsername = EmailUsername.Text;
            string emailPassword = EmailPassword.Text;

            Data.DataAccess validate = new Data.DataAccess();
            int valid = validate.validateUser(username, password);
            //currently set valid to 1
            valid = 1;
            if (valid == 1)
            {
                string[] emailValues = { user, subject, emailUsername, emailPassword, message };
                Email email = new Email();
                email.sendEmail(emailValues,startIndex,items);
            }
            else
            {
                AccountInvalid.Visible = true;
            }
        }

        public void Pagination()
        {
            string filter = FilterValues.SelectedValue;
            double pages = Math.Ceiling(Convert.ToDouble(sellerCount) / Convert.ToInt32(filter));
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

            string pageHtml = "<td><a href='ManageSeller.aspx?page=" + previous +
                "' class='btn btn-primary'> Previous </a></td>";
            for (int i = 1; i <= pages; i++)
            {
                pageHtml += "<td><a href='ManageSeller.aspx?page=" + i +
                    "' class='btn btn-primary'>" + i + "</a></td>";
            }
            pageHtml += "<td><a href='ManageSeller.aspx?page=" + next +
                "' class='btn btn-primary'> Next </a></td>";
            pagination.InnerHtml = "<table style='margin:auto;'><tr>" + pageHtml + "</tr></table>";
        }

        protected void ValueFiltered(object sender, EventArgs e)
        {
            string value = FilterValues.SelectedValue;
            Response.Redirect("ManageSeller.aspx?filter=" + value + "&page=1");
        }
    }
}