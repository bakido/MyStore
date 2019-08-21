using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Repository;
namespace MyStore.Controllers
{
    
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork unit;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            unit = new UnitOfWork(_context);
        }

        [Authorize(Roles = "Admin")]
        // GET: Products
        public  IActionResult Index()
        {
            return View( unit.Products.GetAll().ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = unit.Products.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Description,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                unit.Products.Add(product);
                unit.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (unit.Products.Get(id) == null)
            {
                return NotFound();
            }
            return View(unit.Products.Get(id));
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Description,Price")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }
            

            if (ModelState.IsValid)
            {
                try
                {
                    Product UpdatedProduct = unit.Products.Get(id);
                    UpdatedProduct.ProductName = product.ProductName;
                    UpdatedProduct.Description = product.Description;
                    UpdatedProduct.Price = product.Price;
                    unit.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            unit.Products.Remove(unit.Products.Get(id));
            unit.Complete();
           

            return RedirectToAction("Index");
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.product.FindAsync(id);
            _context.product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.product.Any(e => e.ProductId == id);
        }
    }
}
