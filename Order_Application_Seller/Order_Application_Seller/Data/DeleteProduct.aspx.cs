using System;
using System.Web.Script.Serialization;

namespace Order_Application_Seller.Data
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int productVal = Convert.ToInt32(Request.QueryString["productVal"]);

                ProductDetailsReference.ProductViewSoapClient product = new ProductDetailsReference.ProductViewSoapClient();

                int deleted = product.deleteProduct(productVal);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(deleted);
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