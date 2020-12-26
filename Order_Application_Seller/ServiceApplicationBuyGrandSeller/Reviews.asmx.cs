using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceApplicationBuyGrandSeller/Review.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Reviews : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public Review[] GetTopReviews(int productID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("ItemReview");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getItemReview", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("productId", productID);
                    adapter.Fill(table);
                    Review[] reviews = new Review[table.Rows.Count];

                    if (table.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Review review = new Review();
                            review.reviewID = Convert.ToInt32(row["reviewID"].ToString());
                            review.reviewDesc = row["description"].ToString();
                            review.imagePath = row["imagePath"].ToString();
                            review.datetime = row["submittedDate"].ToString();
                            review.name = row["name"].ToString();
                            review.subReviewCount = Convert.ToInt32(row["subReviewCount"].ToString());
                            reviews[i] = review;
                            i++;
                        }
                    }

                    return reviews;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public Review[] GetSubReviews(int productID,int reviewID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("ItemReview");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getItemSubReview", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("productId", productID);
                    adapter.SelectCommand.Parameters.AddWithValue("reviewId", reviewID);
                    adapter.Fill(table);
                    Review[] reviews = new Review[table.Rows.Count];

                    if (table.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Review review = new Review();
                            review.reviewID = Convert.ToInt32(row["reviewID"].ToString());
                            review.reviewDesc = row["description"].ToString();
                            review.imagePath = row["imagePath"].ToString();
                            review.datetime = row["submittedDate"].ToString();
                            review.name = row["name"].ToString();
                            reviews[i] = review;
                            i++;
                        }
                    }

                    return reviews;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int addReview(int itemID, int originalID, string username, string review)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_AddComment", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("itemID", itemID);
                    command.Parameters.AddWithValue("originalID", originalID);
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("review", review);
                    int added = command.ExecuteNonQuery();
                    return added;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return -1;
            }
        }

        [WebMethod]
        public DataTable getUser(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("Seller");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getUserData", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("username", username);
                    adapter.Fill(table);
                    return table;
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
