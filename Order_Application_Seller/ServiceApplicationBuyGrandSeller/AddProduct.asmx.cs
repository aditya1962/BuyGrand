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
    }
}
