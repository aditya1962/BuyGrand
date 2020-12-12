using System;
using System.Web.UI;

namespace Order_Application_Seller
{
    public partial class ViewItems : System.Web.UI.Page
    {
        YourItemReference.UserItemSoapClient viewItemsRef;
        int page, filter;
        YourItemReference.Item[] items;
        string username;

        protected void Page_Preload(object sender, EventArgs e)
        {
            viewItemsRef = new YourItemReference.UserItemSoapClient();

            if (!IsPostBack)
            {
                int[] filters = (int[])Enum.GetValues(typeof(Data.Enums.Filters));
                foreach (int filtered in filters)
                {
                    FilterList.Items.Add(filtered.ToString());
                }
                filter = Convert.ToInt32(FilterList.SelectedValue);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                username = Session["username"].ToString();
            }
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
            int items = LoadItem(page, filter);
            if (items > 0)
            {
                Pagination();
            }
        }

        protected void FilterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = "ViewItems.aspx?page=1&filter=" + FilterList.SelectedValue;
            Response.Redirect(url);
        }

        public int LoadItem(int page, int filter)
        {
            items = viewItemsRef.items(page, filter,username);

            if (items.Length == 0)
            {
                itemsListDiv.InnerHtml = "<label> There are no items to display </label>";
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    UserItem item = (UserItem)Page.LoadControl("~/UserItem.ascx");
                    item.Id = items[i].id;
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
            //int itemsCount = viewItemsRef.itemCount(username);
            int itemsCount = 20;
            int pages = (int)Math.Ceiling((double)itemsCount / filter);
            int pagesDisplay = pages;
            if (pages > 5)
            {
                pagesDisplay = 5;
            }
            int previous = (page - 1), next = (page + 1);
            if (page == 1)
            {
                previous = 1;
                next = 1;
            }
            if (page == pagesDisplay)
            {
                next = page;
            }
            string pagesHtml = "<div style='display:flex;'>";
            pagesHtml += "<button class='btn btn-primary'><a href='ViewItems.aspx?page=" + previous +
                        "&filter=" + filter + "' class='page-button'>Previous</a></button>";
            for (int i = 1; i <= pagesDisplay; i++)
            {
                pagesHtml += "<button class='btn btn-primary'><a href='ViewItems.aspx?page=" + i +
                        "&filter=" + filter + "' class='page-button'>" + i + "</a></button>";
            }

            pagesHtml += "<button class='btn btn-primary'><a href='ViewItems.aspx?page=" + next +
                        "&filter=" + filter + "' class='page-button'>Next</a></button>";
            pagesHtml += "</div>";
            pagesDiv.InnerHtml = pagesHtml;
        }
    }
}