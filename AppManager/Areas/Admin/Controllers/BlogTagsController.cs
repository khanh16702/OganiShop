using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class BlogTagsController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public BlogTagsController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            var query = _dbContext.BlogTagsEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Name.ToLower().Contains(name.Trim().ToLower()))
                .Where(x => x.IsDeleted == false)
                .Select(x => new BlogTagsModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    CreatedBy = x.CreatedBy,
                    CreateDate = x.CreateDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdateDate = x.UpdateDate,
                    Status = x.Status,
                    IsDeleted = x.IsDeleted,
                });
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.name = name;
            var blogTags = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(blogTags);
        }
        public static string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }
        public static string ToUrlSlug(string value)
        {
            value = RemoveVietnameseTone(value);

            value = value.ToLowerInvariant();

            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            value = value.Trim('-', '_');

            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
        public IActionResult AddOrUpdate (int id, int pageNumber)
        {
            var viewModel = new BlogTagsModel();
            if (id > 0)
            {
                var entity = _dbContext.BlogTagsEntities.Find(id);
                viewModel = new BlogTagsModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    CreatedBy = entity.CreatedBy,
                    CreateDate = entity.CreateDate,
                    UpdatedBy = entity.UpdatedBy,
                    UpdateDate = entity.UpdateDate,
                    Status = entity.Status,
                    IsDeleted = entity.IsDeleted
                };
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
        public IActionResult AddOrUpdate(BlogTagsModel model, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/BlogTags/AddOrUpdate?pageNumber=" + pageNumber);
            }
            string slug = ToUrlSlug(model.Name);

            if (model.Id == 0)
            {
                var findSlugQuery = _dbContext.BlogTagsEntities
                                .Where(x => x.Slug == slug)
                                .ToList();
                if (findSlugQuery.Count() > 0)
                {
                    TempData["Error"] = "Slug của tag bị trùng!";
                    return Redirect("/Admin/BlogTags/AddOrUpdate?pageNumber=" + pageNumber);
                }
            }

            if (model.Id == 0)
            {
                var entity = new BlogTagsEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Slug = slug,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedBy = accClaim.Value,
                    UpdatedBy = accClaim.Value,
                    Status = 1,
                    IsDeleted = false
                };
                _dbContext.BlogTagsEntities.Add(entity);
                _dbContext.SaveChanges();

            }
            else
            {
                var entity = _dbContext.BlogTagsEntities.Find(model.Id);
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Slug = slug;
                entity.CreateDate = model.CreateDate;
                entity.UpdateDate = DateTime.Now;
                entity.CreatedBy = model.CreatedBy;
                entity.UpdatedBy = accClaim.Value;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;

                _dbContext.BlogTagsEntities.Update(entity);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/BlogTags/Index?pageNumber=" + pageNumber);
        }

        public IActionResult Delete(int id, int pageNumber)
        {
            var entity = _dbContext.BlogTagsEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.SaveChanges();
            return Redirect("/admin/blogtags/index?pageNumber=" + pageNumber);
        }
    }
}
