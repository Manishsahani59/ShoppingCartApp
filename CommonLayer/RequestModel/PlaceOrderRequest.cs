using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.RequestModel
{
   public class PlaceOrderRequest
    {
        public List<int> Id { get; set; }

        public List<int> Quantity { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public int Zipcode { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
