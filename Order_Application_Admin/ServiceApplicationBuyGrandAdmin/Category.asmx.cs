using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
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
        Logging logging;

        [WebMethod]
        public DataTable categories()
        {
            try
            {                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DataTable categories = new DataTable("Categories");
                    SqlDataAdapter adapter = new SqlDataAdapter("sp_getCategories", connectionString);
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
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
        public string add(string category,string subcategory)
        {
            string message="";
            DataTable validate = validateElements(category, subcategory);
            int rows = validate.Rows.Count;
            if(rows==0)
            {
                int insert = insertElements(category, subcategory);
                if (insert == 1)
                {
                    message = "Category and Subcategory added";
                }
                else
                {
                    message = "Could not add Category and Subcategory";
                }
            }
            else
            {
                message = "Category or Subcategory already exists";
            }
            return message;
        }

        [WebMethod]
        public string updateCategory(string categoryUpdated,string id)
        {
            string message = "";
            DataTable categories = this.categories();
            int row = Convert.ToInt32(id) - 1;
            string category = categories.Rows[row][0].ToString();
            try
            {
                string query = "update dbo.itemCategory set category='" + categoryUpdated + "' where category='" + category + "';";
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query,connection);
                    int x = command.ExecuteNonQuery();
                    if(x > 0)
                    {
                        message = "Category updated successfully";
                    }
                    else
                    {
                        message = "Could not update category";
                    }
                    connection.Close();
                    return message;
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
        public string deleteCategory(string id)
        {
            string message = "";
            DataTable categories = this.categories();
            int row = Convert.ToInt32(id) - 1;
            string category = categories.Rows[row][0].ToString();
            try
            {
                string query = "delete from dbo.itemCategory where category='" + category + "';";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    int x = command.ExecuteNonQuery();
                    if (x > 0)
                    {
                        message = "Category deleted successfully";
                    }
                    else
                    {
                        message = "Could not delete category";
                    }
                    connection.Close();
                    return message;
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
        public DataTable getSubcategories(string id)
        {
            DataTable table = new DataTable("subcategories");
            DataTable categories = this.categories();
            int rowID = Convert.ToInt32(id) - 1;
            string category = categories.Rows[rowID][0].ToString();
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select subcategory from dbo.itemCategory where category='" + category + "';";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(table);
                    connection.Close();
                    return table;
                }
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        public DataTable validateElements(string category, string subcategory)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string select = "select * from dbo.itemCategory where category='" + category + "' and subcategory='" + subcategory + "';";
                    SqlDataAdapter adapter = new SqlDataAdapter(select, connection);
                    adapter.Fill(table);
                    connection.Close();
                }
                return table;
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
            
        }

        public string getLastElements()
        {
            string categoryID = "";
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "select top 1 categoryID from dbo.itemCategory order by categoryID desc;";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    int rows = table.Rows.Count;
                    if(rows > 0)
                    {
                        foreach(DataRow row in table.Rows)
                        {
                            categoryID = row["categoryID"].ToString();
                        }
                    }
                    connection.Close();
                }
                return categoryID;
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
                return null;
            }
        }

        public int insertElements(string category, string subcategory)
        {
            int x = 0;
            string categoryID = getLastElements();
            int categoryIDTemp = Convert.ToInt32(categoryID) + 1;
            categoryID = categoryIDTemp.ToString();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "insert into dbo.itemCategory values('" + categoryID + "','" + category + "','" + subcategory + "');";
                    SqlCommand command = new SqlCommand(query, connection);
                    x = command.ExecuteNonQuery();
                    connection.Close();
                }
                return x;
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
