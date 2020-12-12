using System;
using System.Collections;
using System.Web.Services;

namespace Order_Application_Seller
{
    public partial class Product : System.Web.UI.Page
    {
        string username;
        int item,users;

        ProductDetailsReference.ProductViewSoapClient productRef;
        public string description,name,image_path,productCategory,productSubcategory;
        public double price,discount,rating;
        public int order_count,quantity_available;
        AddProductReference.Category[] categoryList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                username = Session["username"].ToString();
                string id = Session["itemid"].ToString();
                item = Convert.ToInt32(id);

                ProductValue.Value = item.ToString();

                productRef = new ProductDetailsReference.ProductViewSoapClient();
                ProductDetailsReference.Item product = productRef.getItem(item);

                AddProductReference.AddProductSoapClient addProductReference = new AddProductReference.AddProductSoapClient();
                categoryList = addProductReference.getCategoryNames();

                if (categoryList.Length > 0)
                {
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
                            SubcategoryDropdown.Items.Add(categoryList[i].subcategoryName);
                        }
                    }
                    foreach (string categoryValue in category)
                    {
                        CategoryDropdown.Items.Add(categoryValue);
                    }
                }

                users = productRef.loggedInUser(item, username);

                DescriptionLabel.Text = product.description;
                ItemName.Text = product.name;
                ItemImage.ImageUrl = product.image_path;
                productCategory = product.category;
                productSubcategory = product.subcategory;
                ItemPrice.Text = product.price.ToString();
                ItemDiscount.Text = product.discount.ToString();
                ItemRating.Text = product.rating.ToString();
                if (users == 1)
                {
                    OrderCount.Text = product.order_count.ToString();
                }
                else
                {
                    ItemOrderCount.Visible = false;
                    OrderCount.Visible = false;
                }
                Quantity.Text = product.quantity_available.ToString();

                LoadReviews(item);
            }
        }

        [WebMethod]
        protected void addRating(int rating)
        {           
            if (users == 0)
            {
                productRef.addRating(item, rating);
            }
            else if(users==-1)
            {
                RatingError.Text = "Could not add rating";
                RatingError.Visible = true;
            }
            else
            {
                RatingError.Text = "You cannot rate your own product";
                RatingError.Visible = true;
            }
        }

        protected void CategorySelected(object sender, EventArgs e)
        {
            SubcategoryDropdown.Items.Clear();
            for (int i = 0; i < categoryList.Length; i++)
            {
                if (categoryList[i].categoryName.Equals(CategoryDropdown.SelectedItem.Value))
                {
                    SubcategoryDropdown.Items.Add(categoryList[i].subcategoryName);
                }
            }
        }

        public void LoadReviews(int item)
        {
            ReviewsReference.ReviewsSoapClient reviewSoap = new ReviewsReference.ReviewsSoapClient();
            ReviewsReference.Review [] review = reviewSoap.GetTopReviews(item);
            for(int i=0; i<review.Length; i++)
            {
                Review itemReview = (Review)Page.LoadControl("~/Review.ascx");
                itemReview.ImagePath = review[i].imagePath;
                itemReview.ReviewId = review[i].reviewID;
                itemReview.Name = review[i].name;
                itemReview.Description = review[i].reviewDesc;
                itemReview.Datestamp = review[i].datetime;
                itemReview.SubReviews = review[i].subReviewCount;
                ReviewsPlaceHolder.Controls.Add(itemReview);
            }
        }
    }
}