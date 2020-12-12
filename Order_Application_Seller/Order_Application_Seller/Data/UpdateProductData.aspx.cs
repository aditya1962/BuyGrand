using System;
using System.Configuration;
using System.Web.Script.Serialization;

namespace Order_Application_Seller.Data
{
    public partial class UpdateProductData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {              
                int productVal = Convert.ToInt32(Request.QueryString["productVal"]);
                string category = Request.QueryString["category"];
                string subcategory = Request.QueryString["subcategory"];
                string name = Request.QueryString["name"];
                string description = Request.QueryString["description"];
                double price = Convert.ToInt32(Request.QueryString["price"]);
                double discount = Convert.ToDouble(Request.QueryString["discount"]);
                int quantity = Convert.ToInt32(Request.QueryString["quantity"]);
                string filename = Request.QueryString["filename"];
                filename = DateTime.Now.ToString("yyyyMMddHHmmss") + filename;
                string filePath = Server.MapPath("~") + ConfigurationManager.ConnectionStrings["UserFileUploadString"].ConnectionString +
                                    filename;

                ProductDetailsReference.ProductViewSoapClient product = new ProductDetailsReference.ProductViewSoapClient();

                int edited = product.editProductDetail(productVal, category, subcategory, name, description, price, discount, quantity, filePath);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(edited);
                Context.Response.Flush();
                Context.Response.Write(response);
                Context.Response.Flush();
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, "Error", ex.Message);
            }
            finally
            {
                Context.Response.End();
            }
        }
    }
}