using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandSeller
{
    [WebService(Namespace = "http://localhost/AddProduct.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)] 
    [System.Web.Script.Services.ScriptService]
    public class AddProduct : System.Web.Services.WebService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SellerConnectionString"].ConnectionString;
        string rrConnectionString = ConfigurationManager.ConnectionStrings["SellerReadReplicaConnectionString"].ConnectionString;

        [WebMethod]
        public int AddItem(string description, string name, double price,string imagePath, 
                            int quantity, string category, string subcategory)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("sp_addItem", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("description", description);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("price", price);
                    command.Parameters.AddWithValue("imagePath", imagePath);
                    command.Parameters.AddWithValue("quantityAvailable", quantity);
                    command.Parameters.AddWithValue("categoryName", category);
                    command.Parameters.AddWithValue("subcategoryName", subcategory);
                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
            catch(Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return -1;
            }
        }

        [WebMethod]
        public Category[] getCategoryNames()
        {
            try
            {
                using(SqlConnection connection= new SqlConnection(rrConnectionString))
                {
                    DataTable table = new DataTable("CategoryNames");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getCategories", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(table);
                    Category[] categories = new Category[3];
                    //Category[] categories = new Category[table.Rows.Count];
                    if (table.Rows.Count > 0)
                    {
                        int i = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            Category category = new Category();
                            category.categoryName = row["category"].ToString();
                            category.subcategoryName = row["subcategory"].ToString();
                            categories[i] = category;
                            i++;
                        }
                    }
                    
                    Category category1 = new Category();
                    category1.categoryName = "abc";
                    category1.subcategoryName = "abcdef";
                    categories[0] = category1;
                    Category category2 = new Category();
                    category2.categoryName = "abcd";
                    category2.subcategoryName = "abcde";
                    categories[1] = category2;
                    Category category3 = new Category();
                    category3.categoryName = "abc";
                    category3.subcategoryName = "abcdefg";
                    categories[2] = category3;
                    
                    return categories;
                }
            }
            catch(Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
                return null;
            }
        }
    }
}
