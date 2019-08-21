using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.ViewModel
{
    public class OrderDetail
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int quantity { get; set; }
        public double TotalCost { get; set; }
        public string Name { get; set; }

    }
}
