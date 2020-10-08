using System;

namespace ServiceApplicationBuyGrandSeller
{
    public class Item
    {
        public int id { get; set; }

        public String description { get; set; }

        public String name { get; set; }

        public double price { get; set; }

        public String image_path { get; set; }

        public double discount { get; set; }

        public double rating { get; set; }

        public int ratingCount { get; set; }

        public int order_count { get; set; }

        public int quantity_available { get; set; }

        public String category { get; set; }

        public String subcategory { get; set; }

    }
}