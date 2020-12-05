using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/SalesDetails.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SalesDetails : System.Web.Services.WebService
    {
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public DataTable Sales(string startDate, string endDate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("SalesData");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getSales", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("startDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("endDate", endDate);
                    adapter.Fill(table);
                    return table;
                }
            }
            catch(Exception e)
            {
                Logging.WriteLog(e, "Error", e.Message);
                return null;
            }
        }
    }
}
