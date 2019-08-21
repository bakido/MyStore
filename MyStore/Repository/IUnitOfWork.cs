using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;
namespace MyStore.Repository
{
    public interface IUnitOfWork:IDisposable
    {
          IProductRepository Products { get; set; }
          IOrderRepository Orders { get; set; }
                                           
        int Complete();
    }

}
