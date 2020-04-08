using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Order_Application_Admin.Data
{
    public class DataAccess
    {
        private String ConnectionString;
        Logging logging;

        public DataAccess()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        }

        public DataTable getSalesData(string startDate, string endDate)
        {
            DataTable salesData = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            catch(Exception e)
            {
                logging = new Logging();
                logging.logging(e, "Error", e.Message);
                return null;
            }
        }

        public int validateUser(string username, string password)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //hash the password value in the following query
                    string query = "select * from dbo.login where username='" + username + "' and password='" + password + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    int rows = table.Rows.Count;
                    connection.Close();
                    return rows;
                }
            }
            catch (Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }

        }
    }
}