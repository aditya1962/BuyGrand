using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows;
using Order_Application_Admin.Data;

namespace Order_Application_Admin
{
    public partial class AddCategory : System.Web.UI.Page
    {
        Logging logging;
        protected void Page_Load(object sender, EventArgs e)
        {
            logging = new Logging();
            if (!IsPostBack)
            {
                int[] filter = (int[])Enum.GetValues(typeof(Enums.FilterCategories));
                foreach (int filterVal in filter)
                {
                    FilterResults.Items.Add(filterVal.ToString());
                }
                try
                {
                    CategoryReference.CategorySoapClient category = new CategoryReference.CategorySoapClient();
                    DataTable categoryList = category.categories();
                    LoadCategoryDetails(categoryList);
                }
                catch (Exception ex)
                {
                    logging.logging(ex, "Error", ex.Message);
                }
            }
            
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

                    categoryContent+="</td><td><button type='button' class='btn btn-primary' data-toggle='modal'"+
                                "data-target='#editModal' id=edit_" + rowid + " onclick=editClick(this.id)>Edit</button></td><td>" + 
                                "<button type='button' class='btn btn-primary' data-toggle='modal' data-target='#deleteModal' " +
                                "id=delete_" + rowid + " onclick=deleteClick(this.id)>Delete</button></td><td><button type='button'" +
                                "class='btn btn-primary' data-toggle='modal' data-target='#subcategoryModal' id=subcategory_" + rowid +
                                " onclick=subcategoryClick(this.id)> View Subcategories</button></td></tr>";
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

        protected void Edit_Click(object sender, EventArgs e)
        {
            string category = EditCategoryName.Text;
            string username = EditUsername.Text;
            string password = EditPassword.Text;
            Boolean invalid = false;
            if(category=="")
            {
                CategoryBlank.Visible = true;
                invalid = true;
            }
            if(username=="")
            {
                EditUsernameBlank.Visible = true;
                invalid = true;
            }
            if(password=="")
            {
                EditPasswordBlank.Visible = true;
                invalid = true;
            }
            if(!invalid)
            {
                Data.DataAccess da = new Data.DataAccess();
                int valid = da.validateUser(username, password);
                //currently set valid to 1 to portray that username and password exist
                valid = 1;
                if(valid > 0)
                {
                    string id = editValue.Value;
                    CategoryReference.CategorySoapClient categoryClient = new CategoryReference.CategorySoapClient();
                    string updated = categoryClient.updateCategory(category,id);
                    UpdateSuccess.Text = updated;
                    UpdateSuccess.Visible = true;
                }
                else
                {
                    EditAccountInvalid.Visible = true;
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string username = DeleteUsername.Text;
            string password = DeletePassword.Text;
            Boolean invalid = false;
            if (username == "")
            {
                DeleteUsernameBlank.Visible = true;
                invalid = true;
            }
            if (password == "")
            {
                DeletePasswordBlank.Visible = true;
                invalid = true;
            }
            if (!invalid)
            {
                Data.DataAccess da = new Data.DataAccess();
                int valid = da.validateUser(username, password);
                //currently set valid to 1 to portray that username and password exist
                valid = 1;
                if (valid > 0)
                {
                    string id = deleteValue.Value;
                    CategoryReference.CategorySoapClient categoryClient = new CategoryReference.CategorySoapClient();
                    string updated = categoryClient.deleteCategory(id);
                    UpdateSuccess.Text = updated;
                    UpdateSuccess.Visible = true;
                }
                else
                {
                    DeleteAccountInvalid.Visible = true;
                }
            }
        }

        
    }
}