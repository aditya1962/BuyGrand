using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/ManageSeller.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ManageSeller : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        Logging logging;
        [WebMethod]
        public DataTable manageSellers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_manageSellers", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable sellers = new DataTable("Sellers");
                    adapter.Fill(sellers);
                    connection.Close();
                    return sellers;
                }
            }
            catch (Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int delete(string username)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query_1 = "delete from dbo.loggedUser where username='" + username + "'";
                    string query_2 = "delete from dbo.login where username='" + username + "'";

                    SqlCommand command_1 = new SqlCommand(query_1, connection);
                    SqlCommand command_2 = new SqlCommand(query_2, connection);
                    int rowsOne = command_1.ExecuteNonQuery();
                    int rowsTwo = command_2.ExecuteNonQuery();
                    int deleted = 0;
                    if(rowsOne==1 && rowsTwo==1)
                    {
                        deleted = 1;
                    }
                    connection.Close();
                    return deleted;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -1;
            }
        }

        [WebMethod]
        public string getEmail(string username)
        {
            DataTable sellers = manageSellers();
            string query = "username='" + username + "'";
            DataRow [] row = sellers.Select(query);
            string email = row[0][5].ToString();
            return email;
        }
    }
}
