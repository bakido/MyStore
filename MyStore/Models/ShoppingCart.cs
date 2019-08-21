using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ShoppingCart
    {
        public int cartId { get; set; }
        public Product product { get; set; }
        public double TotalCost { get; set; }
        public int MyProperty { get; set; }
    }
}
