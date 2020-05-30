using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.ModelDB
{
       [Table("OrderedProduct")]  
       public class ProductOrder
       {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime ModefyDate { get; set; }

       }
}
