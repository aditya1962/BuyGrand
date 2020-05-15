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
    }
}