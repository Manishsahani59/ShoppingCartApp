using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.RequestModel
{
   public class ProductRequestModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
      
    }
}
