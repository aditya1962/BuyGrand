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
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}