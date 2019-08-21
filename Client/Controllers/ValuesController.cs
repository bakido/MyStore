using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MyStore.Repository;
//using MyStore.Data;
//using MyStore.Models;


namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       
        //UnitOfWork unit;
        //public ValuesController(ApplicationDbContext _context)
        //{
        //    unit = new UnitOfWork(_context);
        //}
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           // unit.Products.Add(new Product { ProductName = "dsfsdfs", Description = "dsmydfsdbook", Price = 430 });
           // unit.Orders.Add(new Order { productId=1223,userId=})
           // unit.Complete();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
