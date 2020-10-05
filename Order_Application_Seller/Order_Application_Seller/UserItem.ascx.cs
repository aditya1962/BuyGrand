using System;

namespace Order_Application_Seller
{
    public partial class UserItem : System.Web.UI.UserControl
    {
        private string _imagePath;
        private string _name;
        private double _price;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; ItemImage.ImageUrl = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; ItemName.Text = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; ItemPrice.Text = "$ " + value.ToString(); }
        }
    }
}