using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.ViewModel;
using MyStore.Repository;
using MyStore.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MyStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        #region member variables
        private readonly ApplicationDbContext _context;
        private static List<Order> ordersList = new List<Order>();
        private readonly IHttpContextAccessor _httpContextAccessor;
        private UnitOfWork unit;
        #endregion

        #region constructors
        public OrderController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            unit = new UnitOfWork(_context);
        }
        #endregion

        #region view products
        public IActionResult Index()
        {
            if (ordersList != null)
            {
                ViewBag.TotalItemsInCart = ordersList.Count();
            }
            else
            {
                ViewBag.TotalItemsInCart = 0;
            }

            List<OrderViewModel> model = new List<OrderViewModel>();
            foreach (var item in unit.Products.GetAll())
            {
                model.Add(new OrderViewModel()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    Price = item.Price,
                    quantity = 0
                });
            }

            return View(model);
        }
        #endregion

        #region Cart operations
        [HttpGet]
        public IActionResult AddItemToCart(int id)
        {

            Product product = unit.Products.Get(id);
            OrderViewModel orderViewModel = new OrderViewModel()
            {
                Description = product.Description,
                Price = product.Price,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                quantity = 1
            };
            if (unit.Orders.checkDuplicateItemsInList(product, ordersList))
            {
                ViewBag.ItemExist = "item already exist please edit the quantity below";
                orderViewModel.quantity = ordersList.Where(x => x.productId == product.ProductId).FirstOrDefault().quantity;
                return View(orderViewModel);
            }

            return View(orderViewModel);
        }

        public IActionResult viewItemsInCart()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            Product productx;
            foreach (var item in ordersList)
            {
                productx = unit.Products.Find(x => x.ProductId == item.productId).FirstOrDefault();
                orderDetails.Add(new OrderDetail()
                {
                    ProductId = productx.ProductId,
                    Description = productx.Description,
                    ProductName = productx.ProductName,
                    quantity = item.quantity,
                    TotalCost = item.TotalCost,
                    Name = _httpContextAccessor.HttpContext.User.Identity.Name
                });

            }
            return View(orderDetails);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddItemToCart(int id, [Bind("ProductId,ProductName,Description,Price,quantity")] OrderViewModel orderViewModel)
        {
            if (id != orderViewModel.ProductId)
            {
                return NotFound();
            }
            Product product = unit.Products.Get(id);
            if (unit.Orders.checkDuplicateItemsInList(product, ordersList))
            {
                ViewBag.ItemExist = "item already exist please edit the quantity below";
                ordersList.Where(x => x.productId == id).FirstOrDefault().quantity = orderViewModel.quantity;
                ordersList.Where(x => x.productId == id).FirstOrDefault().TotalCost = unit.Orders.getTotalCostOfItem(product.Price, orderViewModel.quantity);
                return RedirectToAction("Index");
            }


            if (ModelState.IsValid)
            {
                try
                {

                    ordersList.Add(new Order
                    {
                        OrderDate = DateTime.Now,
                        productId = orderViewModel.ProductId,
                        quantity = orderViewModel.quantity,
                        TotalCost = unit.Orders.getTotalCostOfItem(product.Price, orderViewModel.quantity),
                        userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                    });

                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderViewModel);
        }


        public IActionResult DeleteItemFromCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Order order = ordersList.Where(x => x.productId == id).FirstOrDefault();
            ordersList.Remove(order);

            return RedirectToAction("viewItemsInCart");
        }
        #endregion

        #region Shipping details
        public IActionResult AddShippingDetails()
        {
            unit.Orders.AddRange(ordersList);
            unit.Complete();
            return RedirectToAction("Index");
        }

        #endregion





    }
}
