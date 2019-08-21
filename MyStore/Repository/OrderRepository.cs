using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Models;
using MyStore.Data;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        
        public OrderRepository(ApplicationDbContext _context):base(_context)
        {
         
        }

        public bool checkDuplicateItemsInList(Product product, List<Order> orders)
        {
           

                foreach (var item in orders)
                {
                    if (item.productId == product.ProductId)
                    {
                        return true;
                    }
                }

                return false;
            
        }

        public IEnumerable<Order> getTodaysOrders()
        {
            return null;//new NotImplementedException();
            //return contextd.order.Where(x => x.OrderDate == DateTime.Today).ToList();
        }

        public double getTotalCostOfCart(List<Order> orders)
        {
            return 3.0;
        }

        public double getTotalCostOfItem(double productPrice, int productQuantity)
        {
            //later cater for tax calculation;

            return productQuantity * productPrice;
        }

    }
}
