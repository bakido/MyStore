using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repository
{
    public interface IOrderRepository:IRepository<Order>
    {
        IEnumerable<Order> getTodaysOrders();
        double getTotalCostOfCart(List<Order> orders);
        double getTotalCostOfItem(double productPrice,int productQuantity);
        bool checkDuplicateItemsInList(Product product, List<Order> orders);


    }
}
