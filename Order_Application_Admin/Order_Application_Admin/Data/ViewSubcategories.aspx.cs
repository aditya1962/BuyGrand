using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;

namespace Order_Application_Admin.Data
{
    public partial class ViewSubcategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string category = Request.QueryString["categoryName"];
                category = category.Replace("_", " ");
                CategoryReference.CategorySoapClient categories = new CategoryReference.CategorySoapClient();
                DataTable subcategories = categories.getSubcategories(category);
                List<String> subcategoryList = new List<string>();
                foreach (DataRow row in subcategories.Rows)
                {
                    subcategoryList.Add(row["subcategory"].ToString());
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(subcategoryList);
                Context.Response.Flush();
                Context.Response.Write(response);
                Context.Response.Flush();
            }
            catch(Exception ex)
            {
                Logging logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
            }
            finally
            {
                Context.Response.End();
            }

        }
    }
}