using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Data;

namespace MyStore.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext MysStoreContext;
        public UnitOfWork(ApplicationDbContext _context)
        {
            MysStoreContext = _context;
            Products = new ProductRepository(MysStoreContext);
            Orders = new OrderRepository(MysStoreContext);
            
        }

        public IProductRepository Products { get; set; }
        public IOrderRepository Orders { get; set; }
  

        public int Complete()
        {
            return MysStoreContext.SaveChanges();
        }

        public void Dispose()
        {
            MysStoreContext.Dispose();
        }
    }
}
