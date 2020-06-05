using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class checkoutModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
    public class checkoutData{
        public List<checkoutModel> Checkout { get; set; }
    }
    
}