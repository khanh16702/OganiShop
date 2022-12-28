using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public AccountController(AppDbContext dbContext, IWebHostEnvironment environment)
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
        public IActionResult Login(string ReturnURL)
        {
            ViewBag.ReturnURL = ReturnURL;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountModel model)
        {
            if (model.Password == null)
            {
                TempData["Error"] = "Password input is blank!";
                return Redirect("/admin/account/login");
            }
            string encodedPassword = EncryptPlainTextToCipherText(model.Password);
            var query = _dbContext.AccountEntities
                .Where(x => x.Username == model.Username)
                .Where(x => x.Password == encodedPassword)
                .Select(x => new AccountModel()
                {
                    AccId = x.AccId,
                    Username = x.Username,
                    Password = x.Password
                });
            if (query.Count() == 0)
            {
                TempData["Error"] = "Username or password is not correct";
                return Redirect("/admin/account/login");
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Username.ToLower())
                };
                if (model.Username.ToLower().Contains("admin"))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }
                else if (model.Username.ToLower().Contains("staff"))
                {
                    claims.Add(new Claim(ClaimTypes.Role, "staff"));
                    model.ReturnURL = "/home/index";
                } else
                {
                    model.ReturnURL = "/home/index";
                }
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                var returnURL = string.IsNullOrEmpty(model.ReturnURL) ? "/admin/home/index" : model.ReturnURL;
                return Redirect(returnURL);
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountModel model)
        {
            if (model.Username == null || model.Username.Trim() == "")
            {
                TempData["alertMessage"] = "Username is not valid";
                return Redirect("/admin/account/register");
            }
            if (model.Password == null)
            {
                TempData["alertMessage"] = "Password is not valid";
                return Redirect("/admin/account/register");
            }
            if (model.Password != model.RetypedPassword)
            {
                TempData["alertMessage"] = "Password counldn't be verified";
                return Redirect("/admin/account/register");
            }

            var query = _dbContext.AccountEntities
                .Where(x => x.Username == model.Username)
                .Select(x => new AccountModel()
                {
                    AccId = x.AccId,
                    Username = x.Username
                });

            if (query.Count() != 0)
            {
                TempData["alertmessage"] = "Username already exists";
                return Redirect("/admin/account/register");
            }

            string pass = EncryptPlainTextToCipherText(model.Password);
            var entity = new AccountEntity()
            {
                Username = model.Username,
                Password = pass,
                RetypedPassword = pass,
                ReturnURL = "/home/index",
                Avatar = "~/img/user-default.png",
                CartValue = 0m
            };
            _dbContext.AccountEntities.Add(entity);
            _dbContext.SaveChanges();
            return Redirect(entity.ReturnURL);
        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/admin/account/login");
        }
    }
}
