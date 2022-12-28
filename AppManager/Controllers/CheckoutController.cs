using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _dbContext;
        public CheckoutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
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
                TempData["CheckoutError"] = "";
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            var cartQuery = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            if (cartQuery.Count() == 0)
            {
                TempData["CheckoutError"] = "Your cart is empty!";
                return Redirect("/products/shoppingcart");

            }
            
            var query = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            var acc = query.FirstOrDefault();
            var account = new AccountModel()
            {
                FirstName = acc.FirstName,
                LastName = acc.LastName,
                Country = acc.Country,
                Address = acc.Address,
                Postcode = acc.Postcode,
                Phone = acc.Phone,
                Email = acc.Email,
                OrderNotes = acc.OrderNotes
            };
            return View(account);
        }

        public IActionResult GetInCartProducts()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.CartEntities
                .Join(_dbContext.ProductEntities, a => a.ProductId, b => b.Id, (a,b) => new {a, b})
                .Where(x => x.a.Username == accClaim.Value)
                .ToList();
            List<ProductsInCartModel> products = new List<ProductsInCartModel>();
            foreach (var item in query)
            {
                var product = new ProductsInCartModel()
                {
                    Name = item.b.Name,
                    Total = item.a.SubTotal
                };
                products.Add(product);
            }
            return Json(products);
        }

        public IActionResult GetPrice()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.CartEntities
                .Join(_dbContext.ProductEntities, a => a.ProductId, b => b.Id, (a, b) => new { a, b })
                .Where(x => x.a.Username == accClaim.Value)
                .ToList();
            var subTotal = 0m;
            foreach (var item in query)
            {
                subTotal += item.a.SubTotal;
            }
            var queryAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            var total = queryAcc.CartValue;
            return Json(new { subTotal, total });
        }

        [HttpPost]
        public IActionResult PlaceOrder(AccountModel model)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var query = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            query.FirstName = model.FirstName;
            query.LastName = model.LastName;
            query.Country = model.Country;
            query.Address = model.Address;
            query.Postcode = model.Postcode;
            query.Phone = model.Phone;
            query.Email = model.Email;
            query.OrderNotes = model.OrderNotes;
            _dbContext.AccountEntities.Update(query);

            var salesReceipt = new SalesReceiptEntity()
            {
                CreateDate = DateTime.Now,
                CustomerId = query.AccId
            };
            var discountSell = _dbContext.TypedDiscountEntities
                    .Join(_dbContext.DiscountCodeEntities, a => a.Name, b => b.Name, (a, b) => new { a, b })
                    .Where(x => x.a.Username == accClaim.Value)
                    .ToList();
            var totalDiscount = 0m;
            foreach (var d in discountSell)
            {
                totalDiscount += d.b.ReducedAmount;
            }
            salesReceipt.Discount = totalDiscount;
            _dbContext.SalesReceiptEntities.Add(salesReceipt);
            _dbContext.SaveChanges();

            var cartQuery = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            foreach (var item in cartQuery)
            {
                var sell = new SalesReceiptDetailEntity()
                {
                    SalesReceiptId = salesReceipt.Id,
                    SellQuantity = item.Quantity,
                    ProductId = item.ProductId
                };
                _dbContext.SalesReceiptDetailEntities.Add(sell);
            }
            _dbContext.SaveChanges();

            var typedDiscountCode = _dbContext.TypedDiscountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            foreach(var item in typedDiscountCode)
            {
                _dbContext.TypedDiscountEntities.Remove(item);
                var usedDiscountCode = new UsedDiscountCodeEntity()
                {
                    Name = item.Name,
                    Username = accClaim.Value
                };
                _dbContext.UsedDiscountCodeEntities.Add(usedDiscountCode);
            }

            var cartProducts = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            foreach(var item in cartProducts)
            {
                var productsInStock = _dbContext.ProductEntities.Find(item.ProductId);
                productsInStock.Quantity -= item.Quantity;
                _dbContext.ProductEntities.Update(productsInStock);
                _dbContext.CartEntities.Remove(item);
            }

            var cartValue = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            cartValue.CartValue = 0m;
            _dbContext.AccountEntities.Update(cartValue);

            _dbContext.SaveChanges();
            return Redirect("/home/thankspage");
        }
    }
}
