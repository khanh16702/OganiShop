using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ContactController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View();
        }

        [HttpPost]
        public IActionResult ReceiveContact(ContactMessageModel model)
        {
            var contactMes = new ContactMessageEntity()
            {
                Name = model.Name,
                Email = model.Email,
                Message = model.Message
            };
            _dbContext.ContactMessageEntities.Add(contactMes);
            _dbContext.SaveChanges();
            return Redirect("/contact/thankspage");
        }

        public IActionResult ThanksPage()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var queryAccount = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = queryAccount.FirstOrDefault().CartValue;
                var cartCount = _dbContext.CartEntities
                .Where(x => x.Username == accClaim.Value)
                .ToList();
                ViewBag.CartCount = cartCount.Count();
            }
            else
            {
                ViewBag.CurrentUsername = "";
                ViewBag.CartValue = 0;
                ViewBag.CartCount = 0;
            }
            return View();
        }
    }
}
