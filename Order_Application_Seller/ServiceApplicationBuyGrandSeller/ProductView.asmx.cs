using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/ProductView.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ProductView : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;
        
        [WebMethod]
        public Item getItem(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("ItemDetails");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getItemDetails", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("id", id);
                    adapter.Fill(table);
                    Item item = new Item();

                    if (table.Rows.Count > 0)
                    {
                        DataRow row = table.Rows[0];
                        item.description = row["description"].ToString();
                        item.name = row["name"].ToString();
                        item.price = Convert.ToDouble(row["price"].ToString());
                        item.image_path = row["imagePath"].ToString();
                        item.discount = Convert.ToDouble(row["discount"].ToString());
                        item.rating = Convert.ToDouble(row["rating"].ToString());
                        item.order_count = Convert.ToInt32(row["orderCount"].ToString());
                        item.quantity_available = Convert.ToInt32(row["quantityAvailable"].ToString());
                        item.category = row["category"].ToString();
                        item.subcategory = row["subcategory"].ToString();
                    }
                    return item;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int addRating(int id, int rating)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_addRating", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("rating", rating);
                    int rows = command.ExecuteNonQuery();
                    return rows;
                }
            }
            catch(Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return -1;
            }
        }

        [WebMethod]
        public int loggedInUser(int id,string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_verifyUserForRating", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("username", username);
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
