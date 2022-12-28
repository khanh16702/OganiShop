using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Net.NetworkInformation;
using static System.Net.WebRequestMethods;
using Microsoft.CodeAnalysis;

namespace AppManager.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin,staff")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;

        public ProductController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }

        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 10;
            var query = _dbContext.ProductEntities
                .Join(_dbContext.CategoryEntities, p => p.CategoryId, c => c.Id, (p, c) => new { p, c })
                .Where(x => string.IsNullOrEmpty(name) || x.p.Name.ToLower().Contains(name.Trim().ToLower()))
                .Where(x => x.p.IsDeleted == false)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    Slug = x.p.Slug,
                    Price = x.p.Price,
                    OldPrice = x.p.OldPrice,
                    Description = x.p.Description,
                    SummaryContent = x.p.SummaryContent,
                    Quantity = x.p.Quantity,
                    Weight = x.p.Weight,
                    Unit = x.p.Unit,
                    CategoryId = x.p.CategoryId,
                    CategoryName = x.c.Name,
                    CreatedBy = x.p.CreatedBy,
                    CreateDate = x.p.CreateDate,
                    UpdatedBy = x.p.UpdatedBy,
                    UpdateDate = x.p.UpdateDate,
                    Status = x.p.Status,
                    IsDeleted = x.p.IsDeleted
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
            var viewModel = new ProductViewModel();
            if (id > 0)
            {
                var entity = _dbContext.ProductEntities.Find(id);
                viewModel = new ProductViewModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Slug = entity.Slug,
                    Price = entity.Price,
                    OldPrice = entity.OldPrice,
                    Description = entity.Description,
                    SummaryContent = entity.SummaryContent,
                    Quantity = entity.Quantity,
                    Weight = entity.Weight,
                    Unit = entity.Unit,
                    CategoryId = entity.CategoryId,
                    CreatedBy = entity.CreatedBy,
                    CreateDate = entity.CreateDate,
                    UpdatedBy = entity.UpdatedBy,
                    UpdateDate = entity.UpdateDate,
                    Status = entity.Status,
                    IsDeleted = entity.IsDeleted,
                    IsDiscount = entity.IsDiscount
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
        public IActionResult AddOrUpdate(ProductModel model, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            TempData["User"] = accClaim.Value;
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                TempData["Error"] = error.FirstOrDefault();
                return Redirect("/Admin/Product/AddOrUpdate?pageNumber=" + pageNumber);
            }
            string slug = ToUrlSlug(model.Name);

            if (model.Id == 0)
            {
                var findSlugQuery = _dbContext.ProductEntities
                                .Where(x => x.Slug == slug)
                                .ToList();
                if (findSlugQuery.Count() > 0)
                {
                    TempData["Error"] = "Slug của sản phẩm bị trùng!";
                    return Redirect("/Admin/Product/AddOrUpdate?pageNumber=" + pageNumber);
                }
            }

            var findCategoryQuery = _dbContext.CategoryEntities
                .Where(x => x.Id == model.CategoryId)
                .Where(x => x.IsDeleted == false)
                .ToList();
            if (findCategoryQuery.Count() == 0)
            {
                TempData["Error"] = "Không tìm thấy danh mục tương ứng!";
                return Redirect("/Admin/Product/AddOrUpdate?pageNumber=" + pageNumber);
            }

            if (model.Id == 0)
            {
                var entity = new ProductEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Slug = slug,
                    Price = model.Price,
                    OldPrice = model.OldPrice,
                    Description = model.Description,
                    SummaryContent = model.SummaryContent,
                    Quantity = model.Quantity,
                    Weight = model.Weight,
                    Unit = model.Unit,
                    CategoryId = model.CategoryId,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedBy = accClaim.Value,
                    UpdatedBy = accClaim.Value,
                    Status = 1,
                    IsDeleted = false,
                    IsDiscount = false
                };
                _dbContext.ProductEntities.Add(entity);
                _dbContext.SaveChanges();
            }
            else
            {
                var entity = _dbContext.ProductEntities.Find(model.Id);
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Slug = slug;
                entity.Price = model.Price;
                entity.OldPrice = model.OldPrice;
                entity.Description = model.Description;
                entity.SummaryContent = model.SummaryContent;
                entity.Quantity = model.Quantity;
                entity.Weight = model.Weight;
                entity.Unit = model.Unit;
                entity.CategoryId = model.CategoryId;
                entity.CreateDate = model.CreateDate;
                entity.UpdateDate = DateTime.Now;
                entity.CreatedBy = model.CreatedBy;
                entity.UpdatedBy = accClaim.Value;
                entity.Status = model.Status;
                entity.IsDeleted = model.IsDeleted;
                entity.IsDiscount = model.IsDiscount;

                _dbContext.ProductEntities.Update(entity);
                _dbContext.SaveChanges();
            }

            return Redirect("/Admin/Product/Index?pageNumber=" + pageNumber);
        }

        public IActionResult Delete(int id, int pageNumber)
        {
            var entity = _dbContext.ProductEntities.Find(id);
            //_dbContext.Remove(entity);
            entity.IsDeleted = true;
            _dbContext.SaveChanges();
            return Redirect("/admin/product/index?pageNumber=" + pageNumber);
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
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\product-image");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string filePath = "/img/product-image/" + fileName;
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
        public IActionResult ImageList(int id, int pageNumber)
        {
            var query = (from p in _dbContext.ProductEntities
                         join pImg in _dbContext.ProductImageEntities on p.Id equals pImg.ProductId
                         where pImg.IsDeleted == false
                         where p.Id == id
                         select new ProductImageModel()
                         {
                             Id = pImg.Id,
                             ProductId = pImg.ProductId,
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
            var avatar = (from p in _dbContext.ProductEntities
                          join pImg in _dbContext.ProductImageEntities on p.Id equals pImg.ProductId
                          where pImg.IsDeleted == false
                          where p.Id == id
                          where pImg.IsAvatar == true
                          select new ProductImageModel()
                          {
                              Id = pImg.Id,
                              ProductId = pImg.ProductId,
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
                var avt = new ProductImageModel()
                {
                    Id = 0,
                    ProductId = id,
                    FileId = 0,
                    FilePath = "/img/default.jpg",
                };
                ViewBag.avatar = avt;
            }
            else
            {
                ViewBag.avatar = avatar.FirstOrDefault();
            }
            ViewBag.prdId = id;
            ViewBag.pageNumber = pageNumber;

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
        public IActionResult UpdateProductImage(ProductImageModel productImage, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            _dbContext.ProductImageEntities.Add(new ProductImageEntity()
            {
                ProductId = productImage.ProductId,
                Name = productImage.Name,
                FilePath = productImage.FilePath,
                FileType = "image",
                FileFormat = Path.GetExtension(productImage.FilePath),
                FileId = productImage.FileId,
                IsAvatar = false,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CreatedBy = accClaim.Value,
                UpdatedBy = accClaim.Value,
                Status = 1,
                IsDeleted = false
            });
            _dbContext.SaveChanges();
            return Redirect($"/Admin/Product/ImageList?id={productImage.ProductId}&pageNumber={pageNumber}");
        }
        public IActionResult UpdateProductAvatar(ProductImageModel productImage, int pageNumber)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var query = _dbContext.ProductImageEntities
                .Where(x => x.ProductId == productImage.ProductId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.IsAvatar == true)
                .Select(x => new ProductImageEntity
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
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
                _dbContext.ProductImageEntities.Update(image);
            }
            var ava = _dbContext.ProductImageEntities
                .Where(p => p.Id == productImage.Id)
                .Select(x => new ProductImageEntity
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
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
            _dbContext.ProductImageEntities.Update(ava);

            var productEntity = _dbContext.ProductEntities.Find(ava.ProductId);
            productEntity.ImagePath = ava.FilePath;
            _dbContext.ProductEntities.Update(productEntity);

            _dbContext.SaveChanges();
            return Redirect($"/Admin/Product/ImageList?id={productImage.ProductId}&pageNumber={pageNumber}");
        }
        public IActionResult DeleteImage(int id)
        {
            if (id == -1)
            {
                return Json(new { status = "error" });
            }
            var entity = _dbContext.ProductImageEntities.Find(id);
            entity.IsDeleted = true;
            _dbContext.SaveChanges();
            return Json(new { status = "success" });
        }
    }
}
