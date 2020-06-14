using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartApp.Models
{
    public class checkoutModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

       
       
    }
    public class ListOfCheckout{
        public List<checkoutModel> lstofcheckoutinfo { get; set; }
    }
    
}