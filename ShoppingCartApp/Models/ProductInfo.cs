using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApp.Models
{
    public class ProductInfo
    {
        [Required(ErrorMessage = "Please enter product name.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter product Qunatity.")]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}