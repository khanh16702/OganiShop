using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public BlogController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            var query = _dbContext.BlogEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Title.ToLower().Contains(name.Trim().ToLower()))
                .Where(x => x.IsDeleted == false)
                .Select(x => new BlogViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    ImagePath = x.ImagePath,
                    Summary = x.Summary,
                    Content = x.Content,
                    Comments = x.Comments,
                    BlogCategoryId = x.BlogCategoryId,
                    AuthorImagePath = x.AuthorImagePath,
                    TagsName = x.TagsName,
                    CreatedBy = x.CreatedBy,
                    CreateDate = x.CreateDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdateDate = x.UpdateDate,
                    Status = x.Status,
                    IsDeleted = x.IsDeleted
                });
            var total = query.Count();
            ViewBag.pageCount = Math.Ceiling((decimal)total / pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.title = name;
            var blogs = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            foreach (var blog in blogs)
            {
                var queryCategory = _dbContext.BlogCategoryEntities.Find(blog.BlogCategoryId);
                blog.BlogCategoryName = queryCategory.Name;
            }

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(blogs);
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
        public IActionResult AddOrUpdate(int id, int pageNumber)
        {
            var viewModel = new BlogViewModel();
            if (id > 0)
            {
                var entity = _dbContext.BlogEntities.Find(id);
                viewModel = new BlogViewModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Slug = entity.Slug,
                    BlogCategoryId = entity.BlogCategoryId,
                    ImagePath = entity.ImagePath,
                    Summary = entity.Summary,
                    Content = entity.Content,
                    Comments = entity.Comments,
                    AuthorImagePath = entity.AuthorImagePath,
                    TagsName = entity.TagsName,
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
        public IActionResult AddOrUpdate(BlogModel model, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            string imagePath = "/img/default.jpg";

            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/Blog/AddOrUpdate?pageNumber=" + pageNumber);
            }
            string slug = ToUrlSlug(model.Title);

            if (model.Id == 0)
            {
                var findSlugQuery = _dbContext.BlogEntities
                                .Where(x => x.Slug == slug)
                                .ToList();
                if (findSlugQuery.Count() > 0)
                {
                    TempData["Error"] = "Slug của blog bị trùng!";
                    return Redirect("/Admin/Blog/AddOrUpdate?pageNumber=" + pageNumber);
                }
            }
            else
            {
                var findSlugQuery = _dbContext.BlogEntities
                                .Where(x => x.Slug == slug)
                                .Where(x => x.Id != model.Id)
                                .ToList();
                if (findSlugQuery.Count() > 0)
                {
                    TempData["Error"] = "Slug của blog bị trùng!";
                    return Redirect("/Admin/Blog/AddOrUpdate?pageNumber=" + pageNumber + "&id=" + model.Id);
                }
            }

            var findCategoryQuery = _dbContext.BlogCategoryEntities
                    .Where(x => x.Id == model.BlogCategoryId)
                    .Where(x => x.IsDeleted == false)
                    .ToList();
            if (findCategoryQuery.Count() == 0)
            {
                TempData["Error"] = "Không tìm thấy danh mục tương ứng!";
                return Redirect("/Admin/Blog/AddOrUpdate?pageNumber=" + pageNumber);
            }

            if (model.Id == 0)
            {
                var query = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                if (query.Count() > 0)
                {
                    imagePath = query.FirstOrDefault().Avatar;
                }
                var entity = new BlogEntity()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Slug = slug,
                    BlogCategoryId = model.BlogCategoryId,
                    ImagePath = model.ImagePath,
                    Summary = model.Summary,
                    Content = model.Content,
                    Comments = 0,
                    AuthorImagePath = imagePath,
                    TagsName = model.TagsName,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedBy = accClaim.Value,
                    UpdatedBy = accClaim.Value,
                    Status = 1,
                    IsDeleted = false
                    
                };
                _dbContext.BlogEntities.Add(entity);
                _dbContext.SaveChanges();

                var category = _dbContext.BlogCategoryEntities.Find(model.BlogCategoryId);
                if (category != null)
                {
                    category.NumberOfPost += 1;
                    _dbContext.BlogCategoryEntities.Update(category);
                    _dbContext.SaveChanges();
                }
            }
            else
            {
                var query = _dbContext.AccountEntities
                .Where(x => x.Username == model.CreatedBy)
                .ToList();
                if (query.Count() > 0)
                {
                    imagePath = query.FirstOrDefault().Avatar;
                }
                var entity = _dbContext.BlogEntities.Find(model.Id);
                if (entity.BlogCategoryId != model.BlogCategoryId)
                {
                    var category = _dbContext.BlogCategoryEntities.Find(model.BlogCategoryId);
                    if (category != null)
                    {
                        category.NumberOfPost += 1;
                        _dbContext.BlogCategoryEntities.Update(category);
                    }
                    var categoryDesc = _dbContext.BlogCategoryEntities.Find(entity.BlogCategoryId);
                    if (categoryDesc != null)
                    {
                        categoryDesc.NumberOfPost -= 1;
                        _dbContext.BlogCategoryEntities.Update(category);
                    }
                    entity.BlogCategoryId = model.BlogCategoryId;
                }
                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Slug = slug;
                entity.ImagePath = model.ImagePath;
                entity.Summary = model.Summary;
                entity.Content = model.Content;
                entity.Comments = model.Comments;
                entity.AuthorImagePath = imagePath;
                entity.TagsName = model.TagsName;
                entity.CreateDate = model.CreateDate;
                entity.UpdateDate = DateTime.Now;
                entity.CreatedBy = model.CreatedBy;
                entity.UpdatedBy = accClaim.Value;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;

                _dbContext.BlogEntities.Update(entity);
                _dbContext.SaveChanges();
            }
            return Redirect("/Admin/Blog/Index?pageNumber=" + pageNumber);
        }

        public IActionResult Delete(int id, int pageNumber)
        {
            var entity = _dbContext.BlogEntities.Find(id);
            entity.IsDeleted = true;
            var category = _dbContext.BlogCategoryEntities.Find(entity.BlogCategoryId);
            if (category != null)
            {
                category.NumberOfPost -= 1;
                _dbContext.BlogCategoryEntities.Update(category);
            }
            _dbContext.SaveChanges();
            return Redirect("/admin/blog/index?pageNumber=" + pageNumber);
        }


        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (file == null)
            {
                return Json(new { status = "error" });
            }
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\blog-image");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string filePath = "/img/blog-image/" + fileName;
            var fileEntity = new FileManageEntity()
            {
                Name = file.Name,
                FilePath = filePath,
                FileType = "image",
                FileFormat = Path.GetExtension(filePath),
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreatedBy = accClaim.Value,
                UpdatedBy = accClaim.Value,
                Status = 1,
                IsDeleted = false
            };
            _dbContext.FileManageEntities.Add(fileEntity);
            var status = _dbContext.SaveChanges();
            if (status == 0)
            {
                return Json(new { status = "error" });
            }
            var model = new FileManageModel()
            {
                Name = fileEntity.Name,
                FilePath = fileEntity.FilePath,
                FileType = fileEntity.FileType,
                FileFormat = fileEntity.FileFormat,
                CreateDate = fileEntity.CreateDate,
                UpdateDate = fileEntity.UpdateDate,
                CreatedBy = fileEntity.CreatedBy,
                UpdatedBy = fileEntity.UpdatedBy,
                Status = fileEntity.Status,
                IsDeleted = fileEntity.IsDeleted
            };
            return Json(new
            {
                status = "success",
                fileInfo = model
            });
        }
    }
}
