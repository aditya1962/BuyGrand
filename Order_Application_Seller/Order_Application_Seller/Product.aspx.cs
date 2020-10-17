using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Order_Application_Seller
{
    public partial class Product : System.Web.UI.Page
    {
        ProductDetailsReference.ProductViewSoapClient productRef;
        public string description;
        public string name;
        public string image_path;
        public string category;
        public string subcategory;
        public double price;
        public double discount;
        public double rating;
        public int order_count;
        public int quantity_available;

        protected void Page_Load(object sender, EventArgs e)
        {          
            string Id = Session["itemid"].ToString();
            int productID = Convert.ToInt32(Id);
            productRef = new ProductDetailsReference.ProductViewSoapClient();
            ProductDetailsReference.Item product = productRef.getItem(productID);

            description = product.description;
            name = product.name;
            image_path = product.image_path;
            category = product.category;
            subcategory = product.subcategory;
            price = product.price;
            discount = product.discount;
            rating = product.rating;
            order_count = product.order_count;
            quantity_available = product.quantity_available;

        }
    }
}