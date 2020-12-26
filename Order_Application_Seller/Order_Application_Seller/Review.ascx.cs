using System;

namespace Order_Application_Seller
{
    public partial class Review : System.Web.UI.UserControl
    {
        private string _imagePath;
        private int _reviewID;
        private string _name;
        private string _description;
        private string _datestamp;
        private int _subreviews;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; ProfileIcon.ImageUrl = value; }
        }

        public int ReviewId
        {
            get { return _reviewID; }
            set { _reviewID = value;  ReviewID.Value = value.ToString(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; ProfileName.Text = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; ReviewDescription.Text = value; }
        }

        public string Datestamp
        {
            get { return _datestamp; }
            set { _datestamp = value; DateStamp.Text = getDateTime(value); }
        }

        public int SubReviews
        {
            get { return _subreviews; }
            set {   _subreviews = value;
                    if (value > 0)
                    {
                        MoreReviews.InnerText = "View " + value + " more reviews";
                        MoreReviews.Visible = true;
                    }                  
                }
        }

        public string getDateTime(string value)
        {
            DateTime datestamp = Convert.ToDateTime(value);
            DateTime current = DateTime.Now;
            int difference = 0;
            string stamp = "";

            if(current.Year > datestamp.Year)
            {
                difference = current.Year - datestamp.Year;
                stamp = difference + " years ago";
            }
            else if (current.Month > datestamp.Month)
            {
                difference = current.Month - datestamp.Month;
                stamp = difference + " months ago";
            }
            else if (current.Day > datestamp.Day)
            {
                difference = current.Day - datestamp.Day;
                stamp = difference + " days ago";
            }
            else 
            {
                difference = current.Hour - datestamp.Hour;
                stamp = difference + " hours ago";
            }

            return stamp;
        }
    }
}