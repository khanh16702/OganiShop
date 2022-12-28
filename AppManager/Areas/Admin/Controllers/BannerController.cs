using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Xml.Linq;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class BannerController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public BannerController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            var query = _dbContext.BannerEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Title.ToLower().Contains(name.Trim().ToLower()))
                .Where(x => x.IsDeleted == false)
                .Select(x => new BannerModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    CreatedBy = x.CreatedBy,
                    CreateDate = x.CreateDate,
                    UpdatedBy = x.UpdatedBy,
                    UpdateDate = x.UpdateDate,
                    Status = x.Status,
                    IsDeleted = x.IsDeleted,
                    BigImage = x.BigImage,
                    ToCategoryId = x.ToCategoryId
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

        public IActionResult AddOrUpdate(int id)
        {
            var viewModel = new BannerModel();
            if (id > 0)
            {
                var entity = _dbContext.BannerEntities.Find(id);
                viewModel = new BannerModel()
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Slug = entity.Slug,
                    ImagePath = entity.ImagePath,
                    Content = entity.Content,
                    CreatedBy = entity.CreatedBy,
                    CreateDate = entity.CreateDate,
                    UpdatedBy = entity.UpdatedBy,
                    UpdateDate = entity.UpdateDate,
                    Status = entity.Status,
                    IsDeleted = entity.IsDeleted,
                    BigImage = entity.BigImage,
                    ToCategoryId = entity.ToCategoryId
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
        public IActionResult AddOrUpdate(BannerModel model)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/Banner/AddOrUpdate");
            }
            if (model.Id == 0)
            {
                var toCateQuery = _dbContext.CategoryEntities
                    .Where(x => x.Id == model.ToCategoryId)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
                    .ToList();
                if (toCateQuery.Count() == 0)
                {
                    TempData["Error"] = "Không tìm thấy mã danh mục sản phẩm tương ứng!";
                    return Redirect("/Admin/Banner/AddOrUpdate");
                }
                var entity = new BannerEntity()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content,
                    ImagePath = model.ImagePath,
                    Slug = model.Slug,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedBy = accClaim.Value,
                    UpdatedBy = accClaim.Value,
                    Status = 1,
                    IsDeleted = false,
                    BigImage = false,
                    ToCategoryId = model.ToCategoryId
                };
                _dbContext.BannerEntities.Add(entity);
                _dbContext.SaveChanges();
            }
            else
            {
                var toCateQuery = _dbContext.CategoryEntities
                    .Where(x => x.Id == model.ToCategoryId)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
                    .ToList();
                if (toCateQuery.Count() == 0)
                {
                    TempData["Error"] = "Không tìm thấy mã danh mục sản phẩm tương ứng!";
                    return Redirect($"/Admin/Banner/AddOrUpdate?id={model.Id}");
                }
                var entity = _dbContext.BannerEntities.Find(model.Id);
                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ImagePath = model.ImagePath;
                entity.Slug = model.Slug;
                entity.CreateDate = model.CreateDate;
                entity.UpdateDate = DateTime.Now;
                entity.CreatedBy = model.CreatedBy;
                entity.UpdatedBy = accClaim.Value;
                entity.IsDeleted = model.IsDeleted;
                entity.ToCategoryId = model.ToCategoryId;

                if (model.BigImage == true)
                {
                    var queryBigImg = _dbContext.BannerEntities
                        .Where(x => x.BigImage == true)
                        .ToList();
                    if (queryBigImg.Count > 0)
                    {
                        var oldBigBanner = _dbContext.BannerEntities.Find(queryBigImg.FirstOrDefault().Id);
                        oldBigBanner.BigImage = false;
                        _dbContext.BannerEntities.Update(oldBigBanner);
                    }
                }

                entity.BigImage = model.BigImage;
                if (model.Status == 0)
                {
                    entity.BigImage = false;
                }
                entity.Status = model.Status;
                _dbContext.BannerEntities.Update(entity);
                _dbContext.SaveChanges();
            }

            return Redirect("/Admin/Banner/Index");
        }

        public IActionResult Delete(int id)
        {
            var entity = _dbContext.BannerEntities.Find(id);
            entity.IsDeleted = true;
            entity.BigImage = false;
            _dbContext.SaveChanges();
            return Redirect("/admin/banner/index");
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
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\banner-image");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string filePath = "/img/banner-image/" + fileName;
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
        public IActionResult Image(int id)
        {
            var query = _dbContext.BannerImageEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.BannerId == id)
                .Select(x => new BannerImageModel()
                {
                    Id = x.Id,
                    FilePath = x.FilePath
                }).ToList();
            if (query.Count == 0)
            {
                ViewBag.bannerImage = "/img/default.jpg";
            }
            else
            {
                string path = query.FirstOrDefault().FilePath;
                ViewBag.bannerImage = path;
            }
            ViewBag.bannerId = id;

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.User = accClaim.Value;

            var thisAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            ViewBag.AccAvatar = thisAcc.Avatar;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateBannerImage(BannerImageModel bannerImage)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var query = _dbContext.BannerImageEntities
                .Where(x => x.BannerId == bannerImage.BannerId)
                .Where(x => x.IsDeleted == false)
                .ToList();
            if (query.Count > 0)
            {
                var oldImage = _dbContext.BannerImageEntities.Find(query.FirstOrDefault().Id);
                oldImage.IsDeleted = true;
                _dbContext.BannerImageEntities.Update(oldImage);
                _dbContext.SaveChanges();
            }

            _dbContext.BannerImageEntities.Add(new BannerImageEntity()
            {
                BannerId = bannerImage.BannerId,
                Name = bannerImage.Name,
                FilePath = bannerImage.FilePath,
                FileType = "image",
                FileFormat = Path.GetExtension(bannerImage.FilePath),
                FileId = bannerImage.FileId,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreatedBy = accClaim.Value,
                UpdatedBy = accClaim.Value,
                Status = 1,
                IsDeleted = false
            });

            var banner = _dbContext.BannerEntities.Find(bannerImage.BannerId);
            banner.ImagePath = bannerImage.FilePath;
            _dbContext.BannerEntities.Update(banner);

            _dbContext.SaveChanges();
            return Redirect($"/Admin/Banner/Image?id={bannerImage.BannerId}");
        }
    }
}
