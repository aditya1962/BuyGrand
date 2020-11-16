using System;
using Newtonsoft;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace Order_Application_Seller.Data
{
    public partial class GetReviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int review = Convert.ToInt32(Request.QueryString["review"]);
                int product = Convert.ToInt32(Request.QueryString["product"]);
                ReviewsReference.ReviewsSoapClient reviews = new ReviewsReference.ReviewsSoapClient();
                ReviewsReference.Review[] subreviews = reviews.GetSubReviews(product, review);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(subreviews);
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