using System;
using System.Data;
using Order_Application_Admin.Data;

namespace Order_Application_Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[] filter = (int []) Enum.GetValues(typeof(Enums.FilterCategories));
            foreach(int filterVal in filter)
            {
                FilterResults.Items.Add(filterVal.ToString());
            }
            CategoryReference.CategorySoapClient category = new CategoryReference.CategorySoapClient();
            DataTable categoryList = category.categories();
            LoadCategoryDetails(categoryList);
        }

        public void LoadCategoryDetails(DataTable categories)
        {
            string categoryContent = "";

            string headerRow = "<tr><th style='width:25%;'> Category Name </th><th style='width:10%;'> Number of subcategories </th>" +
                                "<th style='width:10%;'> Number of items </th><th colspan='3'>&nbsp;</th></tr>";
            int categoryCount = categories.Rows.Count;
            if (categoryCount > 0)
            {
                int rowid = 1;
                foreach (DataRow row in categories.Rows)
                {
                    categoryContent += "<tr><td>" + row["category"] +
                                "</td><td>" + row["subcategoryCount"] + "</td><td>";
                    if(row["itemCount"]==DBNull.Value)
                    {
                        categoryContent += "0";
                    }
                    else
                    {
                        categoryContent += row["itemCount"];
                    }
                    categoryContent+="</td><td><input type='button' class='btn btn-primary' id='edit_" + rowid +
                                "' value='Edit'/></td><td><input type='button' class='btn btn-primary' id='" +
                                "delete_" + rowid + "' value='Delete'/></td><td><input type='button'" +
                                "class='btn btn-primary' id='subcategories_" + rowid +
                                "' value='View Subcategories'/></td></tr>";
                    rowid++;
                }
            }
            else
            {
                categoryContent += "<tr><td colspan='7' style='font-size:15px;'> No categories found </td></tr>";
            }
            manageCategoryHtml.InnerHtml += "<table style='width:100%;'>" + headerRow + categoryContent + "</table>";
        }
    }
}