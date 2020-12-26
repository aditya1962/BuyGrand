using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{

    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/GetFeedbacks.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GetFeedbacks : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public Feedback[] ViewFeedbacks(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("FeedbacksData");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getFeedbacks", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("username", username);
                    adapter.Fill(table);
                    
                    if (table.Rows.Count > 0)
                    {
                        Feedback[] feedbacks = new Feedback[table.Rows.Count];

                        for(int i=0; i < table.Rows.Count; i++)
                        {
                            DataRow row = table.Rows[i];
                            Feedback feedback = new Feedback();
                            feedback.id = Convert.ToInt32(row["feedbackID"].ToString());
                            feedback.username = row["username"].ToString();
                            feedback.message = row["message"].ToString();
                            feedback.submittedDate = row["submittedDate"].ToString();
                            feedbacks[i] = feedback;
                        }

                        return feedbacks;
                    }
                    else
                    {
                        return null;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int addReplyToFeedback(int originalID, string reply, string username, string datetime)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_addFeedback", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("originalID", originalID);
                    command.Parameters.AddWithValue("reply", reply);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("datetime", datetime);
                    int rows = command.ExecuteNonQuery();
                    return rows;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return -1;
            }
        }
    }
}
