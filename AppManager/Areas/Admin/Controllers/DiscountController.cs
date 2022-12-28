using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class DiscountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public DiscountController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            int totalCount = 0;
            var queryProduct = _dbContext.ProductEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.Trim().ToLower()))
                .ToList();
            List<DiscountViewModel> discount = new List<DiscountViewModel>();
            foreach (var product in queryProduct)
            {
                var query = _dbContext.DiscountEntities
                    .Where(x => x.ProductId == product.Id)
                    .Where(x => x.IsDeleted == false)
                    .ToList();
                if (query.Count() > 0)
                {
                    var dentity = query.FirstOrDefault();
                    var discountEntity = new DiscountViewModel()
                    {
                        Id = dentity.Id,
                        ProductId = dentity.Id,
                        DiscountPercent = dentity.DiscountPercent,
                        CreateDate = dentity.CreateDate,
                        OutOfDate = dentity.OutOfDate,
                        CreatedBy = dentity.CreatedBy,
                        Status = dentity.Status,
                        IsDeleted = dentity.IsDeleted,
                        ProductName = product.Name
                    };
                    discount.Add(discountEntity);
                    totalCount++;
                }
            }
            ViewBag.pageCount = Math.Ceiling((decimal)totalCount / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var list = discount.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(list);
        }
        public IActionResult AddOrUpdate(int id, int pageNumber)
        {
            var viewModel = new DiscountViewModel();
            if (id > 0)
            {
                var entity = _dbContext.DiscountEntities.Find(id);
                viewModel = new DiscountViewModel()
                {
                    Id = entity.Id,
                    ProductId = entity.ProductId,
                    CreateDate = entity.CreateDate,
                    OutOfDate= entity.OutOfDate,
                    CreatedBy= entity.CreatedBy,
                    DiscountPercent = entity.DiscountPercent,
                    Status = entity.Status,
                    IsDeleted = entity.IsDeleted
                };
                var query = _dbContext.ProductEntities
                    .Where(x => x.Id == id)
                    .ToList();
                viewModel.ProductName = query.FirstOrDefault().Name;
            }
            ViewBag.pageNumber = pageNumber;

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddOrUpdate(DiscountModel model, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/Discount/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
            }
            if (DateTime.Compare(model.CreateDate, DateTime.Now) < 0 || DateTime.Compare(model.CreateDate, model.OutOfDate) > 0)
            {
                TempData["Error"] = "Ngày khuyến mãi không hợp lệ!";
                return Redirect("/Admin/Discount/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
            }

            if (model.Id == 0)
            {
                var checkProductValid = _dbContext.ProductEntities
                    .Where(x => x.Id == model.ProductId);
                if (checkProductValid.Count() == 0)
                {
                    TempData["Error"] = "Không tìm thấy sản phẩm!";
                    return Redirect("/Admin/Discount/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
                }
                var queryFindDiscount = _dbContext.DiscountEntities
                .Where(x => x.ProductId == model.ProductId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
                if (queryFindDiscount.Count() > 0)
                {
                    TempData["Error"] = "Sản phẩm còn đang được áp khuyến mãi!";
                    return Redirect("/Admin/Discount/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
                }
            }
            var queryActiveProduct = _dbContext.ProductEntities
                .Where(x => x.Id == model.ProductId)
                .Where(x => x.Status == 0 || x.IsDeleted == true)
                .ToList();
            if (queryActiveProduct.Count() > 0)
            {
                TempData["Error"] = "Không thể áp khuyến mãi cho sản phẩm! Vui lòng kiểm tra tình trạng sản phẩm!";
                return Redirect("/Admin/Discount/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
            }
            var entity = new DiscountEntity();
            if (model.Id > 0)
            {
                entity.Id = model.Id;
                entity.CreatedBy = model.CreatedBy;
            }
            if (model.Id == 0)
            {
                entity.CreatedBy = accClaim.Value;
            }
            entity.ProductId = model.ProductId;
            entity.CreateDate = model.CreateDate;
            entity.OutOfDate = model.OutOfDate;
            entity.DiscountPercent = model.DiscountPercent;
            if (DateTime.Compare(entity.CreateDate,DateTime.Now) == 0)
            {
                entity.Status = 1;
                var updateProduct = _dbContext.ProductEntities
                    .Where(x => x.Id == model.ProductId);
                var product = updateProduct.FirstOrDefault();
                product.IsDiscount = true;
                if (model.Id == 0)
                    product.OldPrice = product.Price;
                product.Price = product.OldPrice - product.OldPrice * model.DiscountPercent / 100;
                _dbContext.ProductEntities.Update(product);
            }
            else
            {
                entity.Status = 0;
            }
            entity.IsDeleted = false;
            if (model.Id == 0)
            {
                _dbContext.DiscountEntities.Add(entity);
            }
            else
            {
                _dbContext.DiscountEntities.Update(entity);
            }
            _dbContext.SaveChanges();
            ViewBag.pageNumber = pageNumber;
            return Redirect("/admin/discount/index?pageNumber=" + pageNumber);
        }

        public IActionResult Delete(int id, int pageNumber)
        {
            var query = _dbContext.DiscountEntities.Find(id);
            query.IsDeleted = true;
            _dbContext.DiscountEntities.Update(query);
            var productQuery = _dbContext.ProductEntities
                .Where(x => x.Id == query.ProductId);
            foreach(var item in productQuery)
            {
                item.IsDiscount = false;
                if (query.Status == 1)
                {
                    item.Price = item.OldPrice;
                }
                _dbContext.ProductEntities.Update(item);
            }
            _dbContext.SaveChanges();
            return Redirect("/discount/index?pageNumber=" + pageNumber);
        }
    }
}
