using System;
using System.Data;
using Order_Application_Admin.Data;

namespace Order_Application_Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        Logging logging;
        CategoryReference.CategorySoapClient categoryReference;
        int startIndex, endIndex, page, filter;
        DataTable categories;

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int[] filter = (int[])Enum.GetValues(typeof(Enums.FilterCategories));
                foreach (int filterVal in filter)
                {
                    FilterResults.Items.Add(filterVal.ToString());
                }
            }
            logging = new Logging();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                categoryReference = new CategoryReference.CategorySoapClient();
            }
            catch (Exception ex)
            {
                logging.logging(ex, "Error", ex.Message);
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
                FilterResults.SelectedValue = Request["filter"];
            }

            filter = Convert.ToInt32(FilterResults.SelectedValue);
            startIndex = (page - 1) * filter;
            endIndex = filter;

            LoadCategoryDetails();
            Pagination();
        }

        public void LoadCategoryDetails()
        {
            string categoryContent = "";

            string headerRow = "<tr><th style='width:25%;'> Category Name </th><th style='width:20%;'> Number of subcategories </th>" +
                                "<th style='width:20%;'> Number of items </th><th colspan='3'>&nbsp;</th></tr>";

            categories = categoryReference.categories(startIndex, endIndex);
            int categoryCount = categories.Rows.Count;
            if (categoryCount > 0)
            {
                int rowid = 1;
                foreach (DataRow row in categories.Rows)
                {
                    string category = row["category"].ToString();
                    categoryContent += "<tr><td class='category-values'>" + category +
                                "</td><td class='category-values'>" + row["subcategoryCount"] + 
                                "</td><td class='category-values'>";
                    if (row["itemCount"] == DBNull.Value)
                    {
                        categoryContent += "0";
                    }
                    else
                    {
                        categoryContent += row["itemCount"];
                    }
                    category = category.Replace(" ", "_");
                    categoryContent += "</td><td class='control-btn'><button type='button' class='btn btn-primary' data-toggle='modal'" +
                                "data-target='#editModal' id=edit_" + rowid + " onclick=editClick(this.id) title='Edit Category'>Edit</button>" +
                                "</td><td class='control-btn'><button type='button' class='btn btn-primary' data-toggle='modal'" +
                                " data-target='#deleteModal' id=delete_" + rowid + " onclick=deleteClick(this.id) title='Delete Category'>Delete" +
                                "</button></td><td class='control-btn' style='border-right:1px solid #000000;'>" +
                                "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#subcategoryModal' id=" + category +
                                " onclick=subcategoryClick(this.id) title='View subcategories of category'> View Subcategories</button></td></tr>";
                    rowid++;
                }
            }
            else
            {
                categoryContent += "<tr><td colspan='7' style='font-size:15px;'> No categories found </td></tr>";
            }
            manageCategoryHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + categoryContent + "</table>";
        }

        protected void addcategory_Click(object sender, EventArgs e)
        {
            string categoryText = category.Text;
            string subcategoryText = subcategory.Text;

            CategoryReference.CategorySoapClient addCategory = new CategoryReference.CategorySoapClient();
            string message = addCategory.add(categoryText, subcategoryText);
            AddMessage.Text = message;
            AddMessage.Visible = true;
        }

        protected void FilterResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = FilterResults.SelectedValue;
            Response.Redirect("AddCategory.aspx?page=1&filter=" + filter);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string categoryUpdated = EditCategoryName.Text;
            string username = EditUsername.Text;
            string password = EditPassword.Text;
            Data.DataAccess da = new Data.DataAccess();
            int valid = da.validateUser(username, password);
            //currently set valid to 1 to portray that username and password exist
            valid = 1;
            if (valid > 0)
            {
                int id = Convert.ToInt32(editValue.Value);
                DataRow row = categories.Rows[id];
                CategoryReference.CategorySoapClient categoryClient = new CategoryReference.CategorySoapClient();
                string updated = categoryClient.updateCategory(categoryUpdated, row["category"].ToString());
                UpdateSuccess.Text = updated;
                UpdateSuccess.Visible = true;
            }
            else
            {
                EditAccountInvalid.Visible = true;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;
            Data.DataAccess da = new Data.DataAccess();
            int valid = da.validateUser(username, password);
            //currently set valid to 1 to portray that username and password exist
            valid = 1;
            if (valid > 0)
            {
                int id = Convert.ToInt32(editValue.Value);
                DataRow row = categories.Rows[id];
                CategoryReference.CategorySoapClient categoryClient = new CategoryReference.CategorySoapClient();
                string updated = categoryClient.deleteCategory(row["category"].ToString());
                UpdateSuccess.Text = updated;
                UpdateSuccess.Visible = true;
            }
            else
            {
                DeleteAccountInvalid.Visible = true;
            }
        }

        public void Pagination()
        {
            string paginationDivHtml = "";
            double pages = Math.Ceiling((double)categories.Rows.Count / filter);
            int previous = 1, next = 1;
            if (page == 1)
            {
                previous = 1;
            }
            if(page==pages)
            {
                next = page;
            }
            if(page > 1)
            {
                previous = page - 1;
                next = page + 1;
            }
            paginationDivHtml += "<td><button class='btn btn-primary previous'><a href='AddCategory.aspx?page=" + previous +
                                    "&filter=" + filter + "'>Previous</a></td>";
            for (int i = 1; i <= pages; i++)
            {
                paginationDivHtml += "<td><button class='btn btn-primary' style='margin:0% 2%;'><a href='AddCategory.aspx?page=" + i + "&filter=" + filter +
                                    "'>" + i + "</a></td>";
            }
            paginationDivHtml += "<td><button class='btn btn-primary next'><a href='AddCategory.aspx?page=" + next +
                                    "&filter=" + filter + "'>Next</a></td>";
            paginationDiv.InnerHtml = "<table style='margin:auto;'><tr>" + paginationDivHtml + "</tr></table>";
        }
    }
}