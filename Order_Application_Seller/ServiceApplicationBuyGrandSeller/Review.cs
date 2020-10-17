using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApplicationBuyGrandSeller
{
    public class Review
    {
        public int reviewID { get; set; }

        public int subReviewCount { get; set; }

        public string imagePath { get; set; }

        public string name { get; set; }

        public string datetime { get; set; }

        public string reviewDesc { get; set; }
    }
}