using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Helpers;
using System.Xml.Linq;

namespace AppManager.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int categoryId, string name)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (name != null)
            {
                var findProductByName = _dbContext.ProductEntities
                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                if (findProductByName.Count() == 0)
                {
                    return Redirect($"/products/finderror?name={name}");
                }
                ViewBag.categoryId = categoryId;
                ViewBag.productName = name;
                if (accClaim != null)
                {
                    ViewBag.CurrentUsername = accClaim.Value;
                    var query = _dbContext.AccountEntities
                        .Where(x => x.Username == accClaim.Value);
                    ViewBag.CartValue = query.FirstOrDefault().CartValue;
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
            ViewBag.categoryId = categoryId;

            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var query = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = query.FirstOrDefault().CartValue;
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

        public IActionResult GetFeaturedCategories()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            List<SalesReceiptDetailModel> sales = new List<SalesReceiptDetailModel>();
            var query = _dbContext.SalesReceiptDetailEntities
                .ToList();
            foreach(var item in query)
            {
                var f = 0;
                foreach (var sale in sales)
                {
                    if (item.ProductId == sale.ProductId)
                    {
                        sale.SellQuantity += item.SellQuantity;
                        f = 1;
                        break;
                    }
                }
                if (f == 1)
                {
                    continue;
                }
                var s = new SalesReceiptDetailModel()
                {
                    ProductId = item.ProductId,
                    SellQuantity = item.SellQuantity
                };
                sales.Add(s);
            }
            var returnSales = sales.OrderBy(sales => sales.SellQuantity).ThenBy(sales => sales.ProductId).Reverse();
            List<CategoryMixItUpModel> topCategories = new List<CategoryMixItUpModel>();
            var index = 0;
            foreach(var item in returnSales)
            {
                index++;
                if (index == 9)
                {
                    break;
                }
                var f = 0;
                var queryCategory = _dbContext.CategoryEntities
                    .Join(_dbContext.ProductEntities, a => a.Id, b => b.CategoryId, (a, b) => new { a, b })
                    .Where(x => x.b.Id == item.ProductId)
                    .FirstOrDefault();
                foreach (var c in topCategories)
                {
                    if (queryCategory.a.Id == c.Id)
                    {
                        f = 1;
                        break;
                    }
                }
                if (f == 1)
                {
                    continue;
                }
                var category = new CategoryMixItUpModel()
                {
                    Id = queryCategory.a.Id,
                    Name = queryCategory.a.Name,
                    Slug = queryCategory.a.Slug,
                    ImagePath = queryCategory.a.ImagePath
                };
                topCategories.Add(category);
            }

            List<SalesReceiptDetailModel> results = new List<SalesReceiptDetailModel>();
            var cnt = 0;
            foreach(var item in returnSales)
            {
                if (cnt == 8)
                {
                    break;
                }
                results.Add(item);
                cnt++;
            }

            foreach (var topCat in topCategories)
            {
                topCat.Products = new List<ProductViewModel>();
                var productsQuery = _dbContext.ProductEntities
                    .Where(x => x.CategoryId == topCat.Id)
                    .ToList();
                foreach(var product in productsQuery)
                {
                    foreach(var item in results)
                    {
                        if (product.Id == item.ProductId)
                        {
                            var p = new ProductViewModel()
                            {
                                Id = item.ProductId,
                                Name = product.Name,
                                CategoryName = topCat.Name,
                                Price = product.Price,
                                ImagePath = product.ImagePath,
                                CategoryId = product.CategoryId
                            };
                            if (p != null)
                            {
                                topCat.Products.Add(p);
                                break;
                            }
                            else continue;
                        }
                    }
                }
            }
            return Json(topCategories);
        }

        
        public IActionResult FindError(string name)
        {
            ViewBag.productName = name;
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var query = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = query.FirstOrDefault().CartValue;
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

        public IActionResult ShopDetails(int productId)
        {
            var prod = _dbContext.ProductEntities.Find(productId);
            ViewBag.categoryId = prod.CategoryId;
            var category = _dbContext.CategoryEntities.Find(prod.CategoryId);
            ViewBag.categoryName = category.Name;
            var viewProd = new ProductDetailsViewModel()
            {
                Id = prod.Id,
                Name = prod.Name,
                Status = prod.Status,
                Slug = prod.Slug,
                Price = prod.Price,
                Description = prod.Description,
                SummaryContent = prod.SummaryContent,
                Quantity = prod.Quantity,
                Weight = prod.Weight,
                Unit = prod.Unit,
                CategoryId = prod.CategoryId,
                ImagePath = prod.ImagePath
            };
            var paths = new List<string>();
            var query = _dbContext.ProductImageEntities
                .Where(x => x.ProductId == productId)
                .Where(x => x.IsAvatar == false)
                .ToList();
            if (query.Count > 0)
                foreach (var path in query)
                {
                    paths.Add(path.FilePath);
                }
            viewProd.Images = paths;

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
            return View(viewProd);
        }

        public IActionResult ShoppingCart()
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

        public IActionResult GetCartProducts(string productName, string act)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            if (productName == "")
            {
                List<ProductsInCartModel> products = new List<ProductsInCartModel>();
                foreach (var item in query)
                {
                    var product = new ProductsInCartModel()
                    {
                        Quantity = item.Quantity,
                    };
                    var productQuery = _dbContext.ProductEntities.Find(item.ProductId);
                    product.Name = productQuery.Name;
                    product.ImagePath = productQuery.ImagePath;
                    product.Price = productQuery.Price;
                    product.Total = item.SubTotal;
                    products.Add(product);
                }
                return Json(products);
            }
            else
            {
                List<ProductsInCartModel> products = new List<ProductsInCartModel>();
                foreach(var item in query)
                {
                    var product = new ProductsInCartModel();
                    var productQuery = _dbContext.ProductEntities
                        .Where(x => x.Id == item.ProductId)
                        .Where(x => x.Name == productName)
                        .ToList();
                    if (productQuery.Count() > 0)
                    {
                        var _product = productQuery.FirstOrDefault();
                        if (act == "remove")
                        {
                            _dbContext.CartEntities.Remove(item);
                            _dbContext.SaveChanges();
                            continue;
                        }
                        if (act == "inc")
                        {
                            item.Quantity++;
                            _dbContext.CartEntities.Update(item);
                        }
                        if (act == "dec")
                        {
                            item.Quantity--;
                            if (item.Quantity == 0)
                            {
                                item.Quantity = 1;
                            }
                            _dbContext.CartEntities.Update(item);
                        }
                        item.SubTotal = item.Quantity * _product.Price;
                        _dbContext.CartEntities.Update(item);
                        product.Quantity = item.Quantity;
                        product.Name = _product.Name;
                        product.ImagePath = _product.ImagePath;
                        product.Price = _product.Price;
                        product.Total = item.SubTotal;
                        
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        product.Quantity = item.Quantity;
                        var _productQuery = _dbContext.ProductEntities.Find(item.ProductId);
                        product.Name = _productQuery.Name;
                        product.ImagePath = _productQuery.ImagePath;
                        product.Price = _productQuery.Price;
                        product.Total = item.SubTotal;
                    }
                    products.Add(product);
                }
                return Json(products);
            }
        }

        public IActionResult GetCartTotal() 
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            var total = 0m;
            foreach(var item in query)
            {
                total += item.SubTotal;
            }
            var subTotal = total;
            var accountQuery = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value)
                    .ToList();

            var discountCodeQuery = _dbContext.TypedDiscountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            if (discountCodeQuery.Count() > 0)
            {
                foreach (var item in discountCodeQuery)
                {
                    var dcQuery = _dbContext.DiscountCodeEntities
                        .Where(x => x.Name == item.Name);
                    if (total > dcQuery.FirstOrDefault().ReducedAmount)
                        total -= dcQuery.FirstOrDefault().ReducedAmount;
                    else total = 0;
                }
            }
            accountQuery.FirstOrDefault().CartValue = total;
            _dbContext.AccountEntities.Update(accountQuery.FirstOrDefault());
            _dbContext.SaveChanges();
            return Json(new {objSubTotal = subTotal, objTotal = total});
        }

        public IActionResult ApplyCoupon(string discountName)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var cartQuery = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            if (cartQuery.Count() == 0)
            {
                return Json(new { status = "no-products" });
            }

            var query = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value);
            var total = query.FirstOrDefault().CartValue;

            var discountQuery = _dbContext.DiscountCodeEntities
                    .Where(x => x.Name == discountName)
                    .Where(x => !x.IsDeleted)
                    .ToList();
            if (discountQuery.Count() > 0)
            {
                var usedDiscountQuery = _dbContext.UsedDiscountCodeEntities
                    .Where(x => x.Username == accClaim.Value)
                    .Where(x => x.Name == discountName)
                    .ToList();
                if (usedDiscountQuery.Count() > 0)
                {
                    return Json(new { status = "used-discount" });
                }
                var typedDiscountQuery = _dbContext.TypedDiscountEntities
                    .Where(x => x.Username == accClaim.Value)
                    .Where(x => x.Name == discountName)
                    .ToList();
                if (typedDiscountQuery.Count() > 0)
                {
                    return Json(new { status = "typed-discount" });
                }
                var typedDiscount = new TypedDiscountEntity()
                {
                    Username = accClaim.Value,
                    Name = discountName
                };
                _dbContext.TypedDiscountEntities.Add(typedDiscount);
            }
            else
            {
                return Json(new { status = "error" });
            }
            _dbContext.SaveChanges();
            return Json(new { status = "success" });
        }

        public IActionResult TypedDiscountCodesCount()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.TypedDiscountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            var count = query.Count();
            return Json(count);
        }
        public IActionResult ClearTypedDiscountCodes()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.TypedDiscountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            foreach(var item in query)
            {
                _dbContext.TypedDiscountEntities.Remove(item);
            }
            _dbContext.SaveChanges();
            return Json(new { status = "success" });
        }
        public IActionResult updateProductInCartQuantity(string productName, int quantity, string act)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            var query = _dbContext.CartEntities
                .Join(_dbContext.ProductEntities, a => a.ProductId, b => b.Id, (a, b) => new { a, b })
                .Where(x => x.a.Username == accClaim.Value)
                .Where(x => x.b.Name == productName)
                .ToList();
            var item = query.FirstOrDefault();
            if (act == "dec")
                item.a.Quantity = quantity - 1;
            else item.a.Quantity = quantity + 1;
            item.a.SubTotal = item.a.Quantity * item.b.Price;
            _dbContext.CartEntities.Update(item.a);
            _dbContext.SaveChanges();
            return Redirect("/products/shoppingcart");
        }

        public IActionResult GetAllProduct(int categoryId, string name, int sortValue, string minAmount, string maxAmount)
        {
            List<ProductEntity> productList = new List<ProductEntity>();
            decimal minPrice = 0;
            decimal maxPrice = 0;
            if (minAmount == null)
            {
                minPrice = 0;
                maxPrice = decimal.MaxValue;
            }
            else
            {
                minPrice = decimal.Parse(minAmount.Substring(1));
                maxPrice = decimal.Parse(maxAmount.Substring(1));
            }
            if (name != null)
            {
                var findProductByName = _dbContext.ProductEntities
                    .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                    .Where(x => x.Price >= minPrice)
                    .Where(x => x.Price <= maxPrice)
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                foreach(var product in findProductByName)
                {
                    productList.Add(product);
                }
                if (sortValue == 1)
                {
                    productList = productList.OrderBy(x => x.Name).ToList();
                }
                if (sortValue == 2)
                {
                    productList = productList.OrderBy(x => x.Price).ToList();
                }
                if (sortValue == 3)
                {
                    productList = productList.OrderBy(x => x.Price).Reverse().ToList();
                }
                return Json(productList);
            }
            if (categoryId == 0)
            {
                var prods1 = _dbContext.ProductEntities
                    .Where(x => x.Price >= minPrice)
                    .Where(x => x.Price <= maxPrice)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
                    .ToList();
                foreach (var product in prods1)
                {
                    productList.Add(product);
                }
                if (sortValue == 1)
                {
                    productList = productList.OrderBy(x => x.Name).ToList();
                }
                if (sortValue == 2)
                {
                    productList = productList.OrderBy(x => x.Price).ToList();
                }
                if (sortValue == 3)
                {
                    productList = productList.OrderBy(x => x.Price).Reverse().ToList();
                }
                return Json(productList);
            }
            var prods2 = _dbContext.ProductEntities
                .Where(x => x.Price >= minPrice)
                .Where(x => x.Price <= maxPrice)
                .Where(x => x.CategoryId == categoryId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
            foreach (var product in prods2)
            {
                productList.Add(product);
            }
            if (sortValue == 1)
            {
                productList = productList.OrderBy(x => x.Name).ToList();
            }
            if (sortValue == 2)
            {
                productList = productList.OrderBy(x => x.Price).ToList();
            }
            if (sortValue == 3)
            {
                productList = productList.OrderBy(x => x.Price).Reverse().ToList();
            }
            return Json(productList);
        }

        public IActionResult GetAllCategory()
        {
            var categories = _dbContext.CategoryEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
            return Json(categories);
        }

        public IActionResult GetAllBanner()
        {
            var banners = _dbContext.BannerEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .Where(x => x.BigImage == false)
                .ToList();
            return Json(banners);
        }

        public IActionResult GetBigBanner()
        {
            var banner = _dbContext.BannerEntities
                .Where(x => x.BigImage == true)
                .ToList();
            return Json(banner);
        }

        public IActionResult GetRelatedProduct(int categoryId, int thisId)
        {
            var query = _dbContext.ProductEntities
                .Where(x => x.CategoryId == categoryId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Id != thisId)
                .ToList();
            return Json(query);
        }

        public IActionResult GetLatestProducts()
        {
            var query = _dbContext.ProductEntities
                .Where(x => x.Status == 1)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreateDate)
                .ToList();
            return Json(query);
        }

        public IActionResult GetSaleProducts ()
        {
            var query = _dbContext.ProductEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .Where(x => x.IsDiscount == true)
                .ToList();

            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach(var item in query)
            {
                var product = new ProductViewModel();
                product.Id = item.Id;
                product.Name = item.Name;
                product.ImagePath = item.ImagePath;
                product.Price = item.Price;
                product.OldPrice = item.OldPrice;
                var categoryQuery = _dbContext.CategoryEntities.Find(item.CategoryId);
                product.CategoryName = categoryQuery.Name;
                var discountQuery = _dbContext.DiscountEntities
                    .Where(x => x.ProductId == item.Id);
                product.DiscountPercent = discountQuery.FirstOrDefault().DiscountPercent;
                products.Add(product);
            }

            return Json(products);
        }

        public IActionResult AddToCart(int productId, int quantity)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim == null)
            {
                TempData["Error"] = "Sign in to continue shopping";
                return Json(new { status = "error-login" });
            }
            if (accClaim.Value.ToLower().Contains("customer")) {
                var inCartQuery = _dbContext.CartEntities
                    .Where(x => x.Username == accClaim.Value)
                    .Where(x => x.ProductId == productId)
                    .ToList();
                if (inCartQuery.Count() > 0)
                {
                    var inCart = inCartQuery.FirstOrDefault();
                    inCart.Quantity += quantity;

                    var checkQuantity = _dbContext.ProductEntities.Find(productId);
                    if (checkQuantity.Quantity < inCart.Quantity)
                    {
                        return Json(new { status = "not-enough-products" });
                    }

                    var findProductQuery = _dbContext.ProductEntities.Find(productId);
                    inCart.SubTotal = findProductQuery.Price * inCart.Quantity;
                    _dbContext.CartEntities.Update(inCart);
                    var accountQuery = _dbContext.AccountEntities
                        .Where(x => x.Username == accClaim.Value);
                    accountQuery.FirstOrDefault().CartValue += quantity * findProductQuery.Price;
                    _dbContext.AccountEntities.Update(accountQuery.FirstOrDefault());
                }
                else
                {
                    var entity = new CartEntity()
                    {
                        Username = accClaim.Value,
                        ProductId = productId,
                        Quantity = quantity
                    };

                    var checkQuantity = _dbContext.ProductEntities.Find(productId);
                    if (checkQuantity.Quantity < entity.Quantity)
                    {
                        return Json(new { status = "not-enough-products" });
                    }

                    var findProductQuery = _dbContext.ProductEntities.Find(productId);
                    entity.SubTotal = entity.Quantity * findProductQuery.Price;
                    var accountQuery = _dbContext.AccountEntities
                        .Where(x => x.Username == accClaim.Value);
                    accountQuery.FirstOrDefault().CartValue += quantity * findProductQuery.Price;
                    _dbContext.AccountEntities.Update(accountQuery.FirstOrDefault());
                    _dbContext.CartEntities.Add(entity);
                }
                
                _dbContext.SaveChanges();
                return Json(new { status = "success" });
            }
            else
            {
                return Json(new { status = "error-notcustomer" });
            }
        }
    }
}
