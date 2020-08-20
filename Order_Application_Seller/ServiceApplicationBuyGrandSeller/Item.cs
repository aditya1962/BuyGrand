using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApplicationBuyGrandSeller
{
    public class Item
    {
        public String description { get; set; }
        public String name { get; set; }
        public double price { get; set; }
        public String image_path { get; set; }
        public double discount { get; set; }
        public int rating { get; set; }
        public int order_count { get; set; }
        public int quantity_available { get; set; }
        public String category { get; set; }
        public String subcategory { get; set; }

    }
}