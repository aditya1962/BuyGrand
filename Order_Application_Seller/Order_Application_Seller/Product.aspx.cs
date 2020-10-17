using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class Product : System.Web.UI.Page
    {
        string username;
        int productID,users;

        ProductDetailsReference.ProductViewSoapClient productRef;
        public string description,name,image_path,category,subcategory;
        public double price,discount,rating;
        public int order_count,quantity_available;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            string id = Session["itemid"].ToString();
            productID = Convert.ToInt32(id);

            productRef = new ProductDetailsReference.ProductViewSoapClient();
            ProductDetailsReference.Item product = productRef.getItem(productID);

            users = productRef.loggedInUser(productID, username);

            description = product.description;
            name = product.name;
            image_path = product.image_path;
            category = product.category;
            subcategory = product.subcategory;
            price = product.price;
            discount = product.discount;
            rating = product.rating;
            if(users == 1)
            {
                order_count = product.order_count;
            }
            else
            {
                ItemOrderCount.Visible = false;
                OrderCount.Visible = false;
            }
            quantity_available = product.quantity_available;

        }

        [WebMethod]
        protected void addRating(int rating)
        {           
            if (users == 0)
            {
                productRef.addRating(productID, rating);
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
    }
}