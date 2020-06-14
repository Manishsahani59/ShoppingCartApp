using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class PlaceOreder
    {
        public string Name { get; set; }
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public int Zipcode { get; set; }

        public string State { get; set; }

        public string City { get; set; }


    }
}