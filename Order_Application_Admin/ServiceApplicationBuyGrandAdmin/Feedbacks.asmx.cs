using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/feedbacks.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Feedbacks : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
        Logging logging;

        [WebMethod]
        public DataTable viewFeedbacks()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_viewFeedbacks", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable feedbacks = new DataTable("Feedbacks");
                    adapter.Fill(feedbacks);
                    connection.Close();
                    return feedbacks;
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
        public string getUsername(string feedbackID)
        {
            DataTable feedbacks = viewFeedbacks();
            string username = "";
            if(feedbacks.Rows.Count > 0)
            {
                string query = "feedbackID=" + feedbackID;
                DataRow[] row = feedbacks.Select(query);

                username = row[0][1].ToString();
            }
            return username;
        }

        [WebMethod]
        public int addAdminFeedback(string username,string feedback)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string id = getFeedbackId();
                    string query = "insert into dbo.feedbackAdmin values('" + id + "','" + username +
                                    "','" + feedback + "','" + DateTime.Now.ToString() + "');";
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

        public string getFeedbackId()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select top 1(feedbackID) from dbo.feedbackAdmin order by feedbackID desc";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    string feedbackID = "";
                    if(table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        int id = Convert.ToInt32(row["feedbackID"].ToString()) + 1;
                        feedbackID = id.ToString();
                    }
                    else
                    {
                        feedbackID = "1";
                    }
                    return feedbackID;
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
