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
        int page, filter;

        protected void Page_Preload(object sender, EventArgs e)
        {
            viewItemsRef = new ViewProductReference.ViewItemsSoapClient();
         
            if(!IsPostBack)
            {
                int[] filters = (int[])Enum.GetValues(typeof(Data.Enums.Filters));
                foreach (int filtered in filters)
                {
                    FilterList.Items.Add(filtered.ToString());
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            page = 1;
            if (!String.IsNullOrEmpty(Request["page"]))
            {
                page = Convert.ToInt32(Request["page"]);
            }
            if (!String.IsNullOrEmpty(Request["filter"]))
            {
                filter = Convert.ToInt32(Request["filter"]);
            }
            FilterList.SelectedValue = filter.ToString();
            LoadItem(page,filter);
            Pagination();
        }

        protected void FilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = "ViewProduct.aspx?page=1&filter=" + FilterList.SelectedValue;
            Response.Redirect(url);
        }

        public void LoadItem(int page, int filter)
        {

        }

        public void Pagination()
        {
         
        }
    }
}