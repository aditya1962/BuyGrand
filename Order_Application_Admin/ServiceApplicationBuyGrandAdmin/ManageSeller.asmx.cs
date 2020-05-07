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
        public DataTable manageSellers(int startindex,int endindex)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_manageSellers", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("offset", startindex);
                    adapter.SelectCommand.Parameters.AddWithValue("rowstoreturn", endindex);
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
                    SqlCommand command = new SqlCommand("sp_deleteSeller", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);
                    
                    int rows = command.ExecuteNonQuery();
                    int deleted = 0;
                    if(rows>0)
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
        public string getEmail(string username,int startindex,int endindex)
        {
            DataTable sellers = manageSellers(startindex,endindex);
            string query = "username='" + username + "'";
            DataRow [] row = sellers.Select(query);
            string email = row[0][5].ToString();
            return email;
        }
    }
}
