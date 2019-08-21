using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Models;
using MyStore.Data;
namespace MyStore.Repository
{
    public class ProductRepository:Repository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context):base(context)
        {
           
        }
        public IEnumerable<Product> GetFirstTenProducts()
        {
            return contextd.product.Take(10).ToList();
        }
    }
}
