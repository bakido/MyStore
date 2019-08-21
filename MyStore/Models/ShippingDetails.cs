using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ShippingDetails
    {
        [Key]
        public int ShippingID { get; set; }
        public int ContactNumber { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        
    }
}
