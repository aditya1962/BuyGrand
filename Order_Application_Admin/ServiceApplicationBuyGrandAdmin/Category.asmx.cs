using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/category.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Category : System.Web.Services.WebService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        [WebMethod]
        public DataTable categories()
        {
            try
            {                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable categories = new DataTable("Categories");
                    DataTable listOfCategories = listCategories();
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getCategories", connectionString);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    foreach(DataRow row in listOfCategories.Rows)
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("category", row["category"].ToString());
                        DataTable temp = new DataTable();
                        adapter.Fill(temp);
                        categories.Merge(temp);
                    }
                    return categories;
                }
            }
            catch(Exception ex)
            {
                //Log issue with ex.Message
                string message = ex.Message;
                return null;
            }
        }

        public static DataTable listCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataTable dt = new DataTable();
                    string query = "select distinct category from dbo.itemCategory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                //Log issue with ex.Message
                return null;
            }
            
        }
    }
}
