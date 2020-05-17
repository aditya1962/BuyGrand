using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/ViewSales.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ViewSales : System.Web.Services.WebService
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        Logging logging;

        [WebMethod]
        public DataTable getSalesData(string startDate, string endDate)
        {
            DataTable salesData = new DataTable("Sales");
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_generatesalesdata", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("StartDate", startDate);
                    adapter.SelectCommand.Parameters.AddWithValue("EndDate", endDate);
                    adapter.Fill(salesData);
                    connection.Close();
                    return salesData;
                }
            }
            catch (Exception e)
            {
                logging = new Logging();
                logging.logging(e, "Error", e.Message);
                return null;
            }
        }
    }
}
