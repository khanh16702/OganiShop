using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public CategoryController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View();
        }
        public IActionResult GetData([FromBody] RequestModel req)
        {
            var query = _dbContext.CategoryEntities.Where(x => !x.IsDeleted);
            if (!string.IsNullOrEmpty(req.Freetext.Trim()))
            {
                query = query.Where(x => x.Name.ToLower().Contains(req.Freetext));
                ViewBag.name = req.Freetext;
            }
            var res = new ResponseModel<CategoryModel>();
            int skip = req.PageSize * req.PageNumber - req.PageSize;
            res.TotalCount = query.Count();
            res.Data = query.Select(x => new CategoryModel()
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Description = x.Description,
                CreateDate = x.CreateDate,
                CreatedBy = x.CreatedBy,
                UpdateDate = x.UpdateDate,
                UpdatedBy = x.UpdatedBy,
                Status = x.Status,
                IsDeleted = x.IsDeleted,
                ImagePath = x.ImagePath
            })
            .ToList();
            return Json(res);
        }

        public IActionResult AddOrUpdate(int id)
        {
            var viewModel = new CategoryViewModel();
            if (id > 0)
            {
                var entity = _dbContext.CategoryEntities.Find(id);
                viewModel = new CategoryViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Description = entity.Description,
                    CreatedBy = entity.CreatedBy,
                    CreateDate = entity.CreateDate,
                    UpdatedBy = entity.UpdatedBy,
                    UpdateDate = entity.UpdateDate,
                    Status = entity.Status,
                    IsDeleted = entity.IsDeleted,
                    ImagePath = entity.ImagePath
                };
            }

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
        public IActionResult AddOrUpdate(CategoryModel model)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/Category/AddOrUpdate");
            }
            string slug = ToUrlSlug(model.Name);
            if (model.Id == 0)
            {
                var entity = new CategoryEntity()
                {
                    Name = model.Name,
                    Slug = slug,
                    CreatedBy = accClaim.Value,
                    UpdatedBy = accClaim.Value,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    Description = model.Description,
                    Status = 1,
                    IsDeleted = false,
                    ImagePath = ""
                };
                _dbContext.CategoryEntities.Add(entity);
            }
            else
            {
                var entity = _dbContext.CategoryEntities.Find(model.Id);
                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Slug = slug;
                    entity.CreatedBy = model.CreatedBy;
                    entity.CreateDate = model.CreateDate;
                    entity.UpdatedBy = accClaim.Value;
                    entity.UpdateDate = DateTime.Now;
                    entity.Description = model.Description;
                    entity.Status = model.Status;
                    entity.IsDeleted = model.IsDeleted;
                    entity.ImagePath = model.ImagePath;

                    _dbContext.CategoryEntities.Update(entity);
                }
            }
            _dbContext.SaveChanges();
            //return Json(new {status = "success"});
            return Redirect("/Admin/Category/Index");
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
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.CategoryEntities.Find(id);
            //_dbContext.Remove(entity);
            entity.IsDeleted = true;
            var query = _dbContext.ProductEntities
                .Where(x => x.CategoryId == id)
                .ToList();
            if (query.Count() > 0)
            {
                foreach(var item in query)
                {
                    item.Status = 0;
                    _dbContext.ProductEntities.Update(item);
                }
            }
            _dbContext.SaveChanges();
            return Redirect("/admin/category/index");
        }

        public IActionResult Image(int id)
        {
            var query = (from p in _dbContext.CategoryEntities
                         join pImg in _dbContext.CategoryImageEntities on p.Id equals pImg.CategoryId
                         where pImg.IsDeleted == false
                         where p.Id == id
                         select new CategoryImageModel()
                         {
                             Id = pImg.Id,
                             CategoryId = pImg.CategoryId,
                             FileId = pImg.FileId,
                             FileFormat = pImg.FileFormat,
                             FilePath = pImg.FilePath,
                             FileType = pImg.FileType,
                             Name = pImg.Name,
                             IsAvatar = pImg.IsAvatar,
                             CreatedBy = pImg.CreatedBy,
                             UpdatedBy = pImg.UpdatedBy,
                             CreateDate = pImg.CreateDate,
                             UpdateDate = pImg.UpdateDate,
                             IsDeleted = pImg.IsDeleted,
                             Status = pImg.Status
                         }).ToList();
            var avatar = (from p in _dbContext.CategoryEntities
                          join pImg in _dbContext.CategoryImageEntities on p.Id equals pImg.CategoryId
                          where pImg.IsDeleted == false
                          where p.Id == id
                          where pImg.IsAvatar == true
                          select new CategoryImageModel()
                          {
                              Id = pImg.Id,
                              CategoryId = pImg.CategoryId,
                              FileId = pImg.FileId,
                              FileFormat = pImg.FileFormat,
                              FilePath = pImg.FilePath,
                              FileType = pImg.FileType,
                              Name = pImg.Name,
                              IsAvatar = pImg.IsAvatar,
                              CreatedBy = pImg.CreatedBy,
                              UpdatedBy = pImg.UpdatedBy,
                              CreateDate = pImg.CreateDate,
                              UpdateDate = pImg.UpdateDate,
                              IsDeleted = pImg.IsDeleted,
                              Status = pImg.Status
                          }).ToList();
            if (avatar.Count() == 0)
            {
                var avt = new CategoryImageModel()
                {
                    Id = 0,
                    CategoryId = id,
                    FileId = 0,
                    FilePath = "/img/default.jpg",
                };
                ViewBag.categoryAvatar = avt;
            }
            else
            {
                ViewBag.categoryAvatar = avatar.FirstOrDefault();
            }
            ViewBag.catId = id;

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View(query);
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
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\category-image");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string filePath = "/img/category-image/" + fileName;
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

        [HttpPost]
        public IActionResult UpdateCategoryImage(CategoryImageModel categoryImage)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            _dbContext.CategoryImageEntities.Add(new CategoryImageEntity()
            {
                CategoryId = categoryImage.CategoryId,
                Name = categoryImage.Name,
                FilePath = categoryImage.FilePath,
                FileType = "image",
                FileFormat = Path.GetExtension(categoryImage.FilePath),
                FileId = categoryImage.FileId,
                IsAvatar = false,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreatedBy = accClaim.Value,
                UpdatedBy = accClaim.Value,
                Status = 1,
                IsDeleted = false
            });
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Category/Image?id={categoryImage.CategoryId}");
        }
        public IActionResult UpdateCategoryAvatar(CategoryImageModel categoryImage)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var query = _dbContext.CategoryImageEntities
                .Where(x => x.CategoryId == categoryImage.CategoryId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.IsAvatar == true)
                .Select(x => new CategoryImageEntity
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    FileId = x.FileId,
                    FileFormat = x.FileFormat,
                    FilePath = x.FilePath,
                    FileType = x.FileType,
                    Name = x.Name,
                    IsAvatar = x.IsAvatar,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = x.UpdatedBy,
                    CreateDate = x.CreateDate,
                    UpdateDate = x.UpdateDate,
                    IsDeleted = x.IsDeleted,
                    Status = x.Status
                });
            if (query.Any())
            {
                var image = query.First();
                image.IsAvatar = false;
                _dbContext.CategoryImageEntities.Update(image);
            }
            var ava = _dbContext.CategoryImageEntities
                .Where(p => p.Id == categoryImage.Id)
                .Select(x => new CategoryImageEntity
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    FileId = x.FileId,
                    FileFormat = x.FileFormat,
                    FilePath = x.FilePath,
                    FileType = x.FileType,
                    Name = x.Name,
                    IsAvatar = true,
                    CreatedBy = x.CreatedBy,
                    UpdatedBy = accClaim.Value,
                    CreateDate = x.CreateDate,
                    UpdateDate = DateTime.Now,
                    IsDeleted = x.IsDeleted,
                    Status = 1
                }).FirstOrDefault();
            _dbContext.CategoryImageEntities.Update(ava);

            var categoryEntity = _dbContext.CategoryEntities.Find(ava.CategoryId);
            categoryEntity.ImagePath = ava.FilePath;
            _dbContext.CategoryEntities.Update(categoryEntity);

            _dbContext.SaveChanges();
            return Redirect($"/Admin/Category/Image?id={categoryImage.CategoryId}");
        }

        public IActionResult DeleteImage(int id)
        {
            if (id == -1)
            {
                return Json(new { status = "error" });
            }
            var entity = _dbContext.CategoryImageEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.SaveChanges();
            return Json(new { status = "success" });
        }
    }
}
