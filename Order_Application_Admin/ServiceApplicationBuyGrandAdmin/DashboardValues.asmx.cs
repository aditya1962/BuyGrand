using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/DashboardValues.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [System.Web.Script.Services.ScriptService]
    public class DashboardValues : System.Web.Services.WebService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        Logging logging;

        [WebMethod]
        public DataTable GetDashboardData()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getDashboardValues", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dashboard = new DataTable("DashboardData");
                    adapter.Fill(dashboard);
                    connection.Close();
                    return dashboard;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }
    }
}
