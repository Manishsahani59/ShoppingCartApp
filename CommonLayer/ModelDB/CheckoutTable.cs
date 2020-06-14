using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ModelDB
{
    [Table("CheckoutTable")]
   public class CheckoutTable
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        
        public int Quantity { get; set; }
        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }

        public string City { get; set; }

    }
}
