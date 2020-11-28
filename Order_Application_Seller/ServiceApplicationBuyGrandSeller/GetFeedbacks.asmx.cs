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
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;
        [WebMethod]
        public Feedback [] ViewFeedbacks(string username)
        {
            /*
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

                        for(int i=0; i < table.Rows; i++)
                        {
                            DataRow row in table.Rows[i];
                            Feedback feedback = new Feedback();
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
            */
            Feedback[] feedbacks = new Feedback[1];
            Feedback feedback = new Feedback();
            feedback.username = "abc";
            feedback.message = "abcd";
            feedback.submittedDate = "2020/11/22";
            feedbacks[0] = feedback;
            return feedbacks;
        }
    }
}
