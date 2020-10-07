using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/ServiceBuyGrandSeller/ViewItems.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class ViewItems : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;
        
        [WebMethod]
        public Item[] items(int page,int filter)
        {
            page = page - 1;
            Item[] itemsOne = new Item[1];
            /*try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    Logging.WriteLog(null, "", "Connection");
                    DataTable table = new DataTable("ItemDetails");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getItems", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("offset", page);
                    adapter.SelectCommand.Parameters.AddWithValue("rowsToReturn", filter);
                    adapter.Fill(table);
                    Item [] items = new Item [table.Rows.Count];

                    if (table.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Item item = new Item();
                            item.id = Convert.ToInt32(row["itemID"].ToString());
                            item.description = row["description"].ToString();
                            item.name = row["name"].ToString();
                            item.price = Convert.ToInt32(row["price"].ToString());
                            item.image_path = row["imagePath"].ToString();
                            items[i] = item;
                            i++;
                        }
                    }

                    //return items;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
            */
            Item itemOne = new Item();

            itemOne.id = 1;
            itemOne.description = "abc";
            itemOne.name = "abcde";
            itemOne.price = 1;
            itemOne.image_path = "abcdef";
            itemsOne[0] = itemOne;
            return itemsOne;
        }

        [WebMethod]
        public int itemCount()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(rrConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_getItemCount", connection);
                    command.CommandType = CommandType.StoredProcedure;
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
