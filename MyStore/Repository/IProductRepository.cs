using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Models;

namespace MyStore.Repository
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetFirstTenProducts();
    }
}
