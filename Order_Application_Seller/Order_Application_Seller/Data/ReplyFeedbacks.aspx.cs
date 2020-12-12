using System;
using System.Web.Script.Serialization;

namespace Order_Application_Seller.Data
{
    public partial class ReplyFeedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                string reply = Request.QueryString["reply"];
                int originalID = Convert.ToInt32(Request.QueryString["originalID"]);
                string username = Session["username"].ToString();
                string datetime = DateTime.Now.ToString();

                FeedbacksReference.GetFeedbacksSoapClient feedback = new FeedbacksReference.GetFeedbacksSoapClient();

                int added = feedback.addReplyToFeedback(originalID,reply,username,datetime);

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Response.ContentType = "application/json";
                string response = serializer.Serialize(added);
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