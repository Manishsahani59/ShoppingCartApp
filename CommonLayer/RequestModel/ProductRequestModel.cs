using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.RequestModel
{
   public class ProductRequestModel
    {
        [Required(ErrorMessage = "Please enter product name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter product Quantity.")]
        public int Quantity { get; set; }
        
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter product Price.")]
        public int Price { get; set; }
      
    }
}
