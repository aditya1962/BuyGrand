using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows;

namespace Order_Application_Admin
{
    public partial class Add_Subcategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubcategoryReference.SubcategoriesSoapClient subcategories = new SubcategoryReference.SubcategoriesSoapClient();
                DataTable categories = subcategories.getCategories();
                if (categories.Rows.Count > 0)
                {
                    foreach (DataRow row in categories.Rows)
                    {
                        categorylist.Items.Add(new ListItem(row["category"].ToString()));
                        categorylist2.Items.Add(new ListItem(row["category"].ToString()));
                    }
                }
                string category = categorylist2.SelectedValue;
                LoadSubCategoryDetails(category);
            }
        }

        public void LoadSubCategoryDetails(string category)
        {
            string subcategoryContent = "";

            SubcategoryReference.SubcategoriesSoapClient subcategory = new SubcategoryReference.SubcategoriesSoapClient();
            DataTable subcategories = subcategory.getSubcategories(category);

            string headerRow = "<tr><th style='width:15%;'> Category ID </th><th style='width:25%;'> Sub Category Name </th>" +
                                "<th style='width:15%;'> Number of items </th><th colspan='2'>&nbsp;</th></tr>";

            if (subcategories.Rows.Count > 0)
            {
                foreach (DataRow row in subcategories.Rows)
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
            if (subcategoryText == "")
            {
                AddStatus.Text = "Sub category cannot be blank";
                AddStatus.Visible = true;
            }
            else
            {
                SubcategoryReference.SubcategoriesSoapClient subcategories = new SubcategoryReference.SubcategoriesSoapClient();
                int rows = subcategories.subCategoryExists(subcategoryText);
                if (rows > 0)
                {
                    AddStatus.Text = "Sub category already exists";
                    AddStatus.Visible = true;
                }
                else
                {
                    int rowsTwo = subcategories.addSubCategory(category, subcategoryText);
                    if (rowsTwo > 0)
                    {
                        AddStatus.Text = "Sub category added";
                        AddStatus.Visible = true;
                    }
                    else
                    {
                        AddStatus.Text = "Could not add subcategory";
                        AddStatus.Visible = true;
                    }
                }
            }
        }

        protected void categorysearch_Click(object sender, EventArgs e)
        {
            string category = categorylist2.SelectedValue;
            manageSubCategoryHtml.InnerHtml = "";
            LoadSubCategoryDetails(category);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            string categoryID = editValue.Value;
            string subcategory = EditSubCategoryName.Text;
            if (subcategory == "")
            {
                SubCategoryBlank.Visible = true;
            }
            else
            {
                string username = EditUsername.Text;
                string password = EditPassword.Text;
                if (username == "")
                {
                    EditUsernameBlank.Visible = true;
                }
                else if (password == "")
                {
                    EditPasswordBlank.Visible = true;
                }
                else
                {
                    //authenticate user
                    Data.DataAccess da = new Data.DataAccess();
                    int validate = da.validateUser(username, password);
                    //currently set valid to 1 to portray that username and password exist
                    validate = 1;
                    if (validate > 0)
                    {
                        SubcategoryReference.SubcategoriesSoapClient soapClient = new SubcategoryReference.SubcategoriesSoapClient();
                        int rows = soapClient.editSubCategory(categoryID, subcategory);
                        if (rows > 0)
                        {
                            SubcategoryUpdate.Text = "Sub category updated";
                            SubcategoryUpdate.Visible = true;
                        }
                        else
                        {
                            SubcategoryUpdate.Text = "Could not update sub category";
                            SubcategoryUpdate.Visible = true;
                        }
                    }
                    else
                    {
                        EditAccountInvalid.Visible = true;
                    }
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string categoryID = deleteValue.Value;
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;
            if (username == "")
            {
                DeleteUsernameBlank.Visible = true;
            }
            else if (password == "")
            {
                DeletePasswordBlank.Visible = true;
            }
            else
            {
                //authenticate user
                Data.DataAccess da = new Data.DataAccess();
                int validate = da.validateUser(username, password);
                //currently set valid to 1 to portray that username and password exist
                validate = 1;
                if (validate > 0)
                {
                    SubcategoryReference.SubcategoriesSoapClient soapClient = new SubcategoryReference.SubcategoriesSoapClient();
                    int rows = soapClient.deleteSubCategory(categoryID);
                    if (rows > 0)
                    {
                        SubcategoryUpdate.Text = "Sub category deleted";
                        SubcategoryUpdate.Visible = true;
                    }
                    else
                    {
                        SubcategoryUpdate.Text = "Could not delete sub category";
                        SubcategoryUpdate.Visible = true;
                    }
                }
                else
                {
                    DeleteAccountInvalid.Visible = true;
                }
            }
        }
    }
}