using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/ApproveSeller.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [System.Web.Script.Services.ScriptService]
    public class ApproveSeller : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        Logging logging;

        [WebMethod]
        public DataTable approveSellers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_approveSellers", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable sellers = new DataTable("Sellers");
                    adapter.Fill(sellers);
                    connection.Close();
                    return sellers;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int approveSeller(string id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "update dbo.login set activated=1 where username='" + id + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }
        }
    }
}
