using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/Dashboard.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Dashboard : System.Web.Services.WebService
    {
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public DataTable GetDashboard()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("DashboardData");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getDashboardData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(table);
                    return table;
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, "Error", e.Message);
                return null;
            }
        }

        [WebMethod]
        public DataTable GetChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("ChartData");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getChartData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(table);
                    return table;
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, "Error", e.Message);
                return null;
            }
        }


    }
}
