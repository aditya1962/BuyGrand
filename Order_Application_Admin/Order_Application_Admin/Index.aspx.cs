using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Admin
{
    public partial class Index : System.Web.UI.Page
    {
        public string users = "N/A", sellers = "N/A", items = "N/A", categories = "N/A",
                      subcategories = "N/A", orders = "N/A", sales = "N/A";
        Logging logging;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    SalesChart.DataBindTable(reader);
                }
                catch(Exception ex)
                {
                    logging = new Logging();
                    logging.logging(ex, "Error", ex.Message);
                }
            }
                
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            DashboardReference.DashboardValuesSoapClient dashboard = new DashboardReference.DashboardValuesSoapClient();
            DataTable data = dashboard.GetDashboardData();
            if(data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];
                users = row["users"].ToString();
                sellers = row["sellers"].ToString();
                items = row["items"].ToString();
                categories = row["categories"].ToString();
                subcategories = row["subcategories"].ToString();
                orders = row["orders"].ToString();
                sales = row["sales"].ToString();
            }
        }
    }
}