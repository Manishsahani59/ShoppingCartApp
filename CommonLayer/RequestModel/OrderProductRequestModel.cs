using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.RequestModel
{
   public class OrderProductRequestModel
    {
        public int ProductID { get; set; }
        [DefaultValue("flase")]
        public bool isDeleted { get; set; }
        
    }
}
