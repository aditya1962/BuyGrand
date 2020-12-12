using System;
using System.Data;
using System.Web.Script.Serialization;

namespace Order_Application_Seller.Data
{
    public partial class AddComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int originalReview = Convert.ToInt32(Request.QueryString["reviewID"]);
                int product = Convert.ToInt32(Request.QueryString["product"]);
                string review = Request.QueryString["review"];

                string username = Session["username"].ToString();

                ReviewsReference.ReviewsSoapClient reviews = new ReviewsReference.ReviewsSoapClient();

                int added = reviews.addReview(product, originalReview, username, review);

                DataTable table = reviews.getUser(username);

                string[] dataArr = { added.ToString(), table.Rows[0]["name"].ToString(), table.Rows[0]["imagePath"].ToString() };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(dataArr);
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