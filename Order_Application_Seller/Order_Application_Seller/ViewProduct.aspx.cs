using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        ViewProductReference.ViewItemsSoapClient viewItemsRef;

        protected void Page_Preload(object sender, EventArgs e)
        {
            viewItemsRef = new ViewProductReference.ViewItemsSoapClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}