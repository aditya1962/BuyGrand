using System;
using System.Data;
using System.Windows;

namespace Order_Application_Admin
{
    public partial class Add_Subcategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate category list 

            //populate category list 2

            LoadSubCategoryDetails();
        }

        public void LoadSubCategoryDetails()
        {
            string subcategoryContent = "";
            DataTable subcategories = new DataTable();

            string headerRow = "<tr><th style='width:15%;'> Category ID </th><th style='width:25%;'> Sub Category Name </th>" +
                                "<th style='width:15%;'> Number of items </th><th colspan='2'>&nbsp;</th></tr>";
            int subcategoryCount = subcategories.Rows.Count;
            if (subcategoryCount > 0)
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
    }
}