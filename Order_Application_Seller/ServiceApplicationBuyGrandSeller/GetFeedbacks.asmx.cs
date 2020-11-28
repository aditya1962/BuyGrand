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

                        foreach (DataRow row in table.Rows)
                        {
                            Feedback feedback = new Feedback();
                            feedback.username = row["username"].ToString();
                            feedback.message = row["message"].ToString();
                            feedback.submittedDate = row["submittedDate"].ToString();
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
    }
}
