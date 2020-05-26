using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ResponseModel
{
   public class ProductResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt {get;set; }
        public DateTime ModefyAt { get; set; }
    }
}
