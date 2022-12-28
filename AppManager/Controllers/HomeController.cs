using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
                }
            }
            _dbContext.SaveChanges();

            var categories = _dbContext.CategoryEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
            List<CategorySliderItemModel> catList = new List<CategorySliderItemModel>();
            foreach (var category in categories)
            {
                var cat = new CategorySliderItemModel()
                {
                    Title = category.Name,
                    Link = "/" + category.Slug,
                    ImagePath = category.ImagePath,
                    cateId = category.Id
                };
                catList.Add(cat);
            }

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View(catList);
        }

        public IActionResult Privacy()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ThanksPage()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View();
        }
    }
}
