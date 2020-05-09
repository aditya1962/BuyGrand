using System;
using System.Data;
using System.Web.UI.WebControls;
using Order_Application_Admin.Data;

namespace Order_Application_Admin
{
    public partial class Add_Subcategories : System.Web.UI.Page
    {
        SubcategoryReference.SubcategoriesSoapClient subcategories;
        Data.DataAccess da;
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            da = new Data.DataAccess();
            subcategories = new SubcategoryReference.SubcategoriesSoapClient();
            manageSubCategoryHtml.InnerHtml = "";
            if (!IsPostBack)
            {
                int[] values = (int[])Enum.GetValues(typeof(Data.Enums.FilterCategories));
                foreach (int value in values)
                {
                    Filter.Items.Add(new ListItem(value.ToString()));
                }
                DataTable categories = subcategories.getCategories();
                if (categories.Rows.Count > 0)
                {
                    foreach (DataRow row in categories.Rows)
                    {
                        categorylist.Items.Add(new ListItem(row["category"].ToString()));
                        categorylist2.Items.Add(new ListItem(row["category"].ToString()));
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Page_LoadComplete(object sender, EventArgs e)
        {
            string category = categorylist2.SelectedValue;
            manageSubCategoryHtml.InnerHtml = "";
            LoadSubCategoryDetails(category);
        }

        public void LoadSubCategoryDetails(string category)
        {
            string subcategoryContent = "";

            DataTable subcategory = subcategories.getSubcategories(category);

            string headerRow = "<tr><th style='width:15%;'> Category ID </th><th style='width:25%;'> Sub Category Name </th>" +
                                "<th style='width:15%;'> Number of items </th><th colspan='2'>&nbsp;</th></tr>";

            if (subcategory.Rows.Count > 0)
            {
                foreach (DataRow row in subcategory.Rows)
                {
                    subcategoryContent += "<tr><td>" + row["categoryID"] + "</td><td>" + row["subcategory"] +
                                    "</td><td>" + row["itemCount"] + "</td><td>" +
                                    "<button type='button' class='btn btn-primary' data-toggle='modal'" +
                                    "data-target='#editModal' id=edit_" + row["categoryID"] +
                                    " onclick='editClick(this.id)'>Edit</button></td><td><button type='button' class='btn btn-primary' data-toggle='modal'" +
                                    "data-target='#deleteModal' id=delete_" + row["categoryID"] + " onclick='deleteClick(this.id)'>Delete</button></td></tr>";
                }
            }
            else
            {
                subcategoryContent += "<tr><td colspan='5' style='font-size:15px;'> No sub categories found for the chosen category </td></tr>";
            }
            manageSubCategoryHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + subcategoryContent + "</table>";
        }

        protected void addsubcategory_Click(object sender, EventArgs e)
        {
            string category = categorylist.SelectedValue;
            string subcategoryText = subcategory.Text;
            int rows = subcategories.subCategoryExists(subcategoryText);
            if (rows > 0)
            {
                AddStatus.Text = "Sub category already exists";
            }
            else
            {
                int rowsTwo = subcategories.addSubCategory(category, subcategoryText);
                if (rowsTwo > 0)
                {
                    AddStatus.Text = "Sub category added";
                }
                else
                {
                    AddStatus.Text = "Could not add subcategory";
                }
            }
            AddStatus.Visible = true;
        }

        protected void categorysearch_Click(object sender, EventArgs e)
        {
            string category = categorylist2.SelectedValue;
            LoadSubCategoryDetails(category);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string categoryID = editValue.Value;
            string subcategory = EditSubCategoryName.Text;
            string username = EditUsername.Text;
            string password = EditPassword.Text;
            //authenticate user             
            int validate = da.validateUser(username, password);
            //currently set validate to 1 to portray that username and password exist
            validate = 1;
            if (validate > 0)
            {
                int rows = subcategories.editSubCategory(categoryID, subcategory);
                if (rows > 0)
                {
                    SubcategoryUpdate.Text = "Sub category updated";
                }
                else
                {
                    SubcategoryUpdate.Text = "Could not update sub category";
                }
                SubcategoryUpdate.Visible = true;
            }
            else
            {
                EditAccountInvalid.Visible = true;
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string categoryID = deleteValue.Value;
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;
            //authenticate user
            int validate = da.validateUser(username, password);
            //currently set validate to 1 to portray that username and password exist
            validate = 1;
            if (validate > 0)
            {
                int rows = subcategories.deleteSubCategory(categoryID);
                if (rows > 0)
                {
                    SubcategoryUpdate.Text = "Sub category deleted";
                }
                else
                {
                    SubcategoryUpdate.Text = "Could not delete sub category";
                }
                SubcategoryUpdate.Visible = true;
            }
            else
            {
                DeleteAccountInvalid.Visible = true;
            }
        }
    }
}