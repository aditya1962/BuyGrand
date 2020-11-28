using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApplicationBuyGrandSeller
{
    public class Feedback
    {
        public int id { get; set; }

        public string username { get; set; }

        public string message { get; set; }

        public string submittedDate { get; set; }
    }
}