using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using System.Security.Claims;
using AppManager.Areas.Admin.Models;
using System.Security.Cryptography;
using System.Text;

namespace AppManager.Controllers
{
    public class MyAccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public MyAccountController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        private const string SecurityKey = "cJ0u_XXf026";
        public static string EncryptPlainTextToCipherText(string PlainText)
        {
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptCipherTextToPlainText(string CipherText)
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public IActionResult Index()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            if (accClaim == null)
            {
                return Redirect("/admin/account/login");
            }

            var queryAvatar = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            ViewBag.avatar = queryAvatar.FirstOrDefault().Avatar;
            ViewBag.username = queryAvatar.FirstOrDefault().Username;
            ViewBag.password = queryAvatar.FirstOrDefault().Password;

            ViewBag.CurrentUsername = accClaim.Value;
            var query = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
            ViewBag.CartValue = query.FirstOrDefault().CartValue;
            var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
            ViewBag.CartCount = cartCount.Count();

            if (accClaim.Value.ToLower().Contains("admin"))
            {
                ViewBag.Role = "admin";
            }
            if (accClaim.Value.ToLower().Contains("staff"))
            {
                ViewBag.Role = "staff";
            }
            if (accClaim.Value.ToLower().Contains("customer"))
            {
                ViewBag.Role = "customer";
            }
            return View();
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
            string folderUploads = Path.Combine(_environment.WebRootPath, "img\\account-avatar");
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string fullPath = Path.Combine(folderUploads, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string filePath = "/img/account-avatar/" + fileName;
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
        public IActionResult UpdateAccount(AccountModel model)
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);

            var myAcc = _dbContext.AccountEntities
                .Where(x => x.Username == accClaim.Value)
                .FirstOrDefault();
            if (model.Password != null)
            {
                if (model.Password != model.RetypedPassword)
                {
                    TempData["AlertAccount"] = "Confirm password failed";
                    return Redirect("/myaccount/index");
                }
                string pass = EncryptPlainTextToCipherText(model.Password);
                myAcc.Password = pass;
            }
            if (myAcc.Avatar != model.Avatar)
            {
                myAcc.Avatar = model.Avatar;
                var authorImageQuery = _dbContext.BlogEntities
                    .Where(x => x.CreatedBy == myAcc.Username)
                    .ToList();
                if (authorImageQuery.Count() > 0)
                {
                    foreach (var authorImage in authorImageQuery)
                    {
                        authorImage.AuthorImagePath = myAcc.Avatar;
                        _dbContext.BlogEntities.Update(authorImage);
                    }
                }
            }
            _dbContext.AccountEntities.Update(myAcc);
            _dbContext.SaveChanges();
            return Redirect("/myaccount/index");
        }
    }
}
