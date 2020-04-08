using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace ServiceApplicationBuyGrandAdmin
{
    [WebService(Namespace = "http://localhost/Subcategories.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Subcategories : System.Web.Services.WebService
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        Logging logging;
        [WebMethod]
        public DataTable getCategories()
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select distinct category from dbo.itemCategory";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable categories = new DataTable("Categories");
                    adapter.Fill(categories);
                    connection.Close();
                    return categories;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public DataTable getSubcategories(string category)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DataTable subcategories = new DataTable("Subcategories");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getSubCategories", connection);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.Parameters.AddWithValue("category", category);
                    adapter.Fill(subcategories);
                    connection.Close();
                    return subcategories;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int subCategoryExists(string subcategory)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from dbo.itemCategory where subcategory='" + subcategory + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    int rows = table.Rows.Count;
                    connection.Close();
                    return rows;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }
        }

        [WebMethod]
        public int addSubCategory(string subcategory, string category)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string categoryID = this.getCategoryID();
                    string query = "insert into dbo.itemCategory values('" + categoryID + "','" + category + "','" + subcategory + "');";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }
        }

        public string getCategoryID()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select top 1 categoryID from dbo.itemCategory order by categoryID desc";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    string categoryID = "";
                    if (table.Rows.Count > 0)
                    {
                        foreach(DataRow row in table.Rows)
                        {
                            categoryID = row["categoryID"].ToString();
                        }
                        int id = Convert.ToInt32(categoryID) + 1;
                        categoryID = id.ToString();
                    }
                    connection.Close();
                    return categoryID;
                }
            }
            catch (Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        [WebMethod]
        public int editSubCategory(string categoryID, string subcategory)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "update dbo.itemCategory set subcategory='" + subcategory + "' where categoryID='" + categoryID + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }
        }

        [WebMethod]
        public int deleteSubCategory(string categoryID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "delete from dbo.itemCategory where categoryID='" + categoryID + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();
                    connection.Close();
                    return rows;
                }
            }
            catch (Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return -99;
            }
        }
    }
}
