using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public HomeController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index()
        {
            var disableDiscount = _dbContext.DiscountEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .Where(x => DateTime.Compare(x.OutOfDate, DateTime.Now) < 0)
                .ToList();
            if (disableDiscount.Count() > 0)
            {
                foreach (var item in disableDiscount)
                {
                    item.Status = 0;
                    _dbContext.DiscountEntities.Update(item);
                    var updatePriceProduct = _dbContext.ProductEntities
                        .Where(x => x.Id == item.ProductId)
                        .ToList();
                    var p = updatePriceProduct.FirstOrDefault();
                    p.Price = p.OldPrice;
                    p.IsDiscount = false;
                    _dbContext.ProductEntities.Update(p);

                    var cartProduct = _dbContext.CartEntities
                        .Where(x => x.ProductId == item.ProductId)
                        .ToList();
                    foreach (var cart in cartProduct)
                    {
                        cart.SubTotal = p.Price * cart.Quantity;
                        _dbContext.CartEntities.Update(cart);
                    }
                }
            }
            var activeDiscount = _dbContext.DiscountEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 0)
                .Where(x => DateTime.Compare(x.CreateDate, DateTime.Now) <= 0 && DateTime.Compare(x.OutOfDate, DateTime.Now) >= 0)
                .ToList();
            if (activeDiscount.Count() > 0)
            {
                foreach (var item in activeDiscount)
                {
                    item.Status = 1;
                    _dbContext.DiscountEntities.Update(item);
                    var updatePriceProduct = _dbContext.ProductEntities
                        .Where(x => x.Id == item.ProductId)
                        .ToList();
                    var p = updatePriceProduct.FirstOrDefault();
                    p.OldPrice = p.Price;
                    p.Price = p.OldPrice - p.OldPrice * item.DiscountPercent / 100;
                    p.IsDiscount = true;
                    _dbContext.ProductEntities.Update(p);

                    var cartProduct = _dbContext.CartEntities
                        .Where(x => x.ProductId == item.ProductId)
                        .ToList();
                    foreach(var cart in cartProduct)
                    {
                        cart.SubTotal = p.Price * cart.Quantity;
                        _dbContext.CartEntities.Update(cart);
                    }
                }
            }
            _dbContext.SaveChanges();

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;

            var orderQuery = _dbContext.SalesReceiptEntities
                .Where(x => DateTime.Compare(x.CreateDate, DateTime.Now.AddDays(-7)) >= 0 && DateTime.Compare(x.CreateDate, DateTime.Now) <= 0)
                .Count();
            ViewBag.NewOrders = orderQuery;
            return View();
        }

        public IActionResult GetSaleNumber()
        {
            var query = _dbContext.SalesReceiptDetailEntities.ToList();
            var sellQuantity = 0;
            foreach(var item in query)
            {
                sellQuantity += item.SellQuantity;
            }
            var productInStock = 0;
            var inStock = _dbContext.ProductEntities
                .Where(x => !x.IsDeleted)
                .Where(x => x.Status == 1)
                .ToList();
            foreach(var product in inStock)
            {
                productInStock += product.Quantity;
            }
            return Json(new { sellQuantity, productInStock });
        }

        public IActionResult GetRevenueOfMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var query = (from sr in _dbContext.SalesReceiptEntities
                         join srd in _dbContext.SalesReceiptDetailEntities on sr.Id equals srd.SalesReceiptId
                         join p in _dbContext.ProductEntities on srd.ProductId equals p.Id
                         where DateTime.Compare(sr.CreateDate, startDate) >= 0 && DateTime.Compare(sr.CreateDate, endDate) <= 0
                         select new
                         {
                             Revenue = p.Price * srd.SellQuantity
                         });
            var revenue = 0m;
            foreach(var item in query)
            {
                revenue += item.Revenue;
            }
            return Json(revenue);          
        }
    }
}
