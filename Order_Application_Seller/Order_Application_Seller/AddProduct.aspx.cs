using System;
using System.Collections;

namespace Order_Application_Seller
{
    public partial class AddProduct : System.Web.UI.Page
    {
        AddProductReference.AddProductSoapClient addProduct = new AddProductReference.AddProductSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddProductReference.Category[] categoryList = addProduct.getCategoryNames();
                ArrayList category = new ArrayList();
                for (int i = 0; i < categoryList.Length; i++)
                {
                    string categoryName = categoryList[i].categoryName;
                    if (!(category.Contains(categoryName)))
                    {
                        category.Add(categoryName);
                    }
                    if (categoryList[i].categoryName.Equals(categoryList[0].categoryName))
                    {
                        SubCategoryList.Items.Add(categoryList[i].subcategoryName);
                    }
                }
                foreach (string categoryValue in category)
                {
                    CategoryList.Items.Add(categoryValue);
                }
            }
        }

        protected void CategorySelected(object sender, EventArgs e)
        {
            AddProductReference.Category[] categoryList = addProduct.getCategoryNames();
            SubCategoryList.Items.Clear();
            for (int i = 0; i < categoryList.Length; i++)
            {
                if (categoryList[i].categoryName.Equals(CategoryList.SelectedItem.Value))
                {
                    SubCategoryList.Items.Add(categoryList[i].subcategoryName);
                }
            }
        }
    }
}