using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Data;
using MyStore.Repository;

namespace MyStore.Controllers
{
    public class HomeController : Controller
    {
    
        UnitOfWork unit;
        public HomeController(ApplicationDbContext _context)
        {
            unit = new UnitOfWork(_context);
            
        }
        public IActionResult Index()
        {
            //unit.Products.Add(new Product { ProductName = "mybook", Description = "mybook", Price = 430 });

            //unit.Orders.Add(new Order { OrderDate = DateTime.Now, productId = 122, quantity = 5, TotalCost = 5, userId = "userid" });

            //unit.Complete();
            return View(unit.Products.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
