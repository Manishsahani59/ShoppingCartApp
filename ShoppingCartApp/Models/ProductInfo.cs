using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApp.Models
{
    public class ProductInfo
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }

        public string Image { get; set; }
    }
}