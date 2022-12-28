using AppManager.Areas.Admin.Models;
using AppManager.Entities;
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
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppManager.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]    
    
    public class AccountManageController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _environment;
        public AccountManageController(AppDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            _environment = environment;
        }
        public IActionResult Index(string name, int pageNumber = 1)
        {
            int pageSize = 5;
            var query = _dbContext.AccountEntities
                .Where(x => string.IsNullOrEmpty(name) || x.Username.ToLower().Contains(name.Trim().ToLower()))
                .Select(x => new AccountModel()
                {
                    AccId = x.AccId,
                    Username = x.Username,
                    Password = x.Password,
                    Avatar = x.Avatar
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

        public IActionResult Delete(int id, int pageNumber)
        {
            var entity = _dbContext.AccountEntities.Find(id);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return Redirect("/admin/accountmanage/index?pageNumber=" + pageNumber);
        }
    }
}
