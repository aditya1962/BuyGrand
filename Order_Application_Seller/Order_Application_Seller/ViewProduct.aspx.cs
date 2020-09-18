using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        ViewProductReference.ViewItemsSoapClient viewItemsRef;
        int page, filter;
        ViewProductReference.Item[] items;

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
                filter = Convert.ToInt32(FilterList.SelectedValue);
            }
            //itemsListDiv.InnerHtml = "";
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
            int items = LoadItem(page,filter);
            if (items > 0)
            {
                Pagination();
            }            
        }

        protected void FilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = "ViewProduct.aspx?page=1&filter=" + FilterList.SelectedValue;
            Response.Redirect(url);
        }

        public int LoadItem(int page, int filter)
        {           
            items = viewItemsRef.items(page, filter);

            if(items.Length==0)
            {
                itemsListDiv.InnerHtml = "<label> There are no items to display </label>";
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Item item = (Item)Page.LoadControl("~/Item.ascx");
                    item.Name = items[i].name;
                    item.ImagePath = items[i].image_path;
                    item.Price = items[i].price;
                    ItemsHolder.Controls.Add(item);
                    item.Visible = true;
                }
            }
            return items.Length;
        }

        public void Pagination()
        {
            int itemsCount = viewItemsRef.itemCount();
            //itemsCount = 50;
            int pages = (int) Math.Ceiling((double)itemsCount / filter);
            int pagesDisplay = pages;
            if(pages > 5)
            {
                pagesDisplay = 5;
            }
            int previous = (page - 1), next = (page + 1);
            if(page==1)
            {
                previous = 1;
                next = 1;
            }
            if(page==pagesDisplay)
            {
                next = page;
            }
            string pagesHtml = "<div style='display:flex;'>";
            pagesHtml += "<button class='btn btn-primary'><a href='ViewProduct.aspx?page=" + previous + 
                        "&filter=" + filter + "' class='page-button'>Previous</a></button>";
            for(int i = 1; i <= pagesDisplay; i++)
            {
                pagesHtml += "<button class='btn btn-primary'><a href='ViewProduct.aspx?page=" + i +
                        "&filter=" + filter + "' class='page-button'>"+ i + "</a></button>";
            }

            pagesHtml += "<button class='btn btn-primary'><a href='ViewProduct.aspx?page=" + next +
                        "&filter=" + filter + "' class='page-button'>Next</a></button>";
            pagesHtml += "</div>";
            pagesDiv.InnerHtml = pagesHtml;
        }
    }
}