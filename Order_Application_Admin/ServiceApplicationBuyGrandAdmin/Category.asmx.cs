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
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getCategories", connectionString);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(categories);
                    return categories;
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
