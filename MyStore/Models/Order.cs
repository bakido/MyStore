using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        //public IdentityUser user { get; set; }
        public int productId { get; set; }

        //[ForeignKey("productId")]
       // public Product Product { get; set; }
        public int quantity { get; set; }
        public double TotalCost { get; set; }


    }
}
