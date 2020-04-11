using System;
using System.Web.Script.Serialization;

namespace Order_Application_Admin.Data
{
    public partial class ApproveUser : System.Web.UI.Page
    {
        Logging logging;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["userid"];
                SellerReference.ApproveSellerSoapClient approve = new SellerReference.ApproveSellerSoapClient();
                int rows = approve.approveSeller(id);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Context.Response.ContentType = "application/json";
                string serializeRows = serializer.Serialize(rows);
                Context.Response.Write(serializeRows);
            }
            catch(Exception ex)
            {
                logging = new Logging();
                logging.logging(ex, "Error", ex.Message);
            }
            finally
            {
                Context.Response.End();
            }
            
        }
    }
}