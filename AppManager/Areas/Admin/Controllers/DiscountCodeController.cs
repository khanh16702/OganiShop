using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class DiscountCodeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public DiscountCodeController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            var query = _dbContext.DiscountCodeEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.Trim().ToLower()))
                .Where(x => x.IsDeleted == false)
                .Where(x => x.UsedBy == "ADMIN")
                .Select(x => new DiscountCodeModel()
                {
                    Id = x.Id,
                    ReducedAmount = x.ReducedAmount,
                    UsedBy = x.UsedBy,
                    Name = x.Name
                });
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var Index = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(Index);
        }

        public IActionResult AddOrUpdate(int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;
            ViewBag.pageNumber = pageNumber;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View();
        }

        [HttpPost]
        public IActionResult AddOrUpdate(DiscountCodeModel model, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/DiscountCode/AddOrUpdate?pageNumber=" + pageNumber);
            }
            var entity = new DiscountCodeEntity()
            {
                Name = model.Name,
                ReducedAmount = model.ReducedAmount,
                UsedBy = "ADMIN",
                IsDeleted = false
            };
            _dbContext.DiscountCodeEntities.Add(entity);
            _dbContext.SaveChanges();
            return Redirect("/Admin/DiscountCode/Index?pageNumber=" + pageNumber);
        }

        public IActionResult Delete(int id, int pageNumber)
        {
            var entity = _dbContext.DiscountCodeEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.DiscountCodeEntities.Update(entity);
            _dbContext.SaveChanges();
            return Redirect("/Admin/DiscountCode/Index?pageNumber=" + pageNumber);
        }
    }
}
