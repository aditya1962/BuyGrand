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
                LoadSubCategoryDetails();
            }
        }

        public void LoadSubCategoryDetails()
        {
            string subcategoryContent = "";
            string category = categorylist2.SelectedValue;
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
                                    "<input type='button' class='btn btn-primary' id='edit_" + row["categoryID"] +
                                    "' value='Edit'/></td><td><input type='button' class='btn btn-primary' id='" +
                                    "delete_" + row["categoryID"] + "' value='Delete'/></td></tr>";
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
    }
}