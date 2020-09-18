using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/UserItem.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class UserItem : System.Web.Services.WebService
    {

        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public Item[] items(int page, int filter, string username)
        {
            page = page - 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    DataTable table = new DataTable("ItemDetails");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getUserItems", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("offset", page);
                    adapter.SelectCommand.Parameters.AddWithValue("rowsToReturn", filter);
                    adapter.SelectCommand.Parameters.AddWithValue("username", username);
                    adapter.Fill(table);
                    Item[] items = new Item[table.Rows.Count];

                    if (table.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Item item = new Item();
                            item.description = row["description"].ToString();
                            item.name = row["name"].ToString();
                            item.price = Convert.ToInt32(row["price"].ToString());
                            item.image_path = row["imagePath"].ToString();
                            item.discount = Convert.ToDouble(row["discount"].ToString());
                            items[i] = item;
                            i++;
                        }
                    }

                    return items;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int itemCount(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getUserItemCount", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);
                    int items = Convert.ToInt32(command.ExecuteScalar());
                    return items;
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
