using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Order_Application_Seller.Data
{
    public class DataAccess
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        public string getUsersName(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from dbo.loggedUser where username='" + username + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    DataRow row = table.Rows[0];
                    string name = row["firstName"].ToString() + " " + row["lastName"].ToString();
                    connection.Close();
                    return name;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }

        }
    }
}