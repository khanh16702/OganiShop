using AppManager.Areas.Admin.Models;
using AppManager.Entities;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace AppManager.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BlogController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int categoryId, string title, string tag)
        {
            ViewBag.Tag = tag;
            ViewBag.CategoryId = categoryId;
            ViewBag.Name = title;

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var query = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = query.FirstOrDefault().CartValue;
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
        public IActionResult BlogDetails(int blogId)
        {
            var blog = _dbContext.BlogEntities.Find(blogId);
            var modelBlog = new BlogViewModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                ImagePath = blog.ImagePath,
                Slug = blog.Slug,
                Summary = blog.Summary,
                Content = blog.Content,
                Comments = blog.Comments,
                BlogCategoryId = blog.BlogCategoryId,
                AuthorImagePath = blog.AuthorImagePath,
                TagsName = blog.TagsName,
                CustomDate = blog.CreateDate.ToString("MMMM dd, yyyy"),
                UpdateDate = blog.UpdateDate,
                CreatedBy = blog.CreatedBy,
                UpdatedBy = blog.UpdatedBy
            };
            var queryCategoryName = _dbContext.BlogCategoryEntities.Find(modelBlog.BlogCategoryId);
            if (queryCategoryName.IsDeleted == false && queryCategoryName.Status == 1)
            {
                modelBlog.BlogCategoryName = queryCategoryName.Name;
            }

            string[] listTags = modelBlog.TagsName.Split(", ");
            modelBlog.TagsName = "";
            List<string> tagNames = new List<string>();
            foreach (string tag in listTags)
            {
                var queryTags = _dbContext.BlogTagsEntities
                    .Where(x => x.Name == tag)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1);
                if (queryTags.Count() > 0)
                {
                    tagNames.Add(queryTags.FirstOrDefault().Name);
                }
            }
            foreach (string tag in tagNames)
            {
                modelBlog.TagsName += tag + ", ";
            }
            modelBlog.TagsName = modelBlog.TagsName.Substring(0, modelBlog.TagsName.Length - 2);
            if (modelBlog.CreatedBy.ToLower().Contains("admin"))
            {
                modelBlog.AuthorRole = "Admin";
            }
            else
            {
                modelBlog.AuthorRole = "Staff";
            }
            ViewBag.CategoryId = modelBlog.BlogCategoryId;
            ViewBag.thisBlogId = blogId;

            var claims = HttpContext.User.Identity as ClaimsIdentity;
            var accClaim = claims.FindFirst(ClaimTypes.NameIdentifier);
            if (accClaim != null)
            {
                ViewBag.CurrentUsername = accClaim.Value;
                var query = _dbContext.AccountEntities
                    .Where(x => x.Username == accClaim.Value);
                ViewBag.CartValue = query.FirstOrDefault().CartValue;
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
            return View(modelBlog);
        }
        public IActionResult GetBlogCategories()
        {
            var query = _dbContext.BlogCategoryEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
            return Json(query);
        }
        public IActionResult GetBlogs(int categoryId, string title, string tag)
        {
            if (tag != null)
            {
                List<BlogViewModel> blogViewModels = new List<BlogViewModel>();
                var queryFindBlog = _dbContext.BlogEntities
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
                    .ToList();
                foreach (var blog in queryFindBlog)
                {
                    string[] TagsName = blog.TagsName.Split(", ");
                    foreach (string tagName in TagsName)
                    {
                        if (tagName == tag)
                        {
                            BlogViewModel newBlogView = new BlogViewModel()
                            {
                                Id = blog.Id
                            };
                            blogViewModels.Add(newBlogView);
                        }
                    }
                }
                if (title != null)
                {
                    if (categoryId == 0)
                    {
                        var queryAll = _dbContext.BlogEntities
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Status == 1)
                            .Where(x => x.Title.ToLower().Contains(title.ToLower()))
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
                                CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                            })
                            .ToList();

                        List<BlogViewModel> finalList = new List<BlogViewModel>();
                        foreach (var iblog in queryAll)
                        {
                            foreach(var jblog in blogViewModels)
                            {
                                if (iblog.Id == jblog.Id)
                                {
                                    finalList.Add(iblog);
                                }
                            }
                        }
                        return Json(finalList);
                    }
                    else
                    {
                        List<BlogViewModel> finalList = new List<BlogViewModel>();
                        var query = _dbContext.BlogEntities
                            .Where(x => x.BlogCategoryId == categoryId)
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Status == 1)
                            .Where(x => x.Title.ToLower().Contains(title.ToLower()))
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
                                CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                            })
                            .ToList();
                        foreach (var iblog in query)
                        {
                            foreach (var jblog in blogViewModels)
                            {
                                if (iblog.Id == jblog.Id)
                                {
                                    finalList.Add(iblog);
                                }
                            }
                        }
                        return Json(finalList);
                    }
                }
                else
                {
                    if (categoryId == 0)
                    {
                        var queryAll = _dbContext.BlogEntities
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Status == 1)
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
                                CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                            })
                            .ToList();

                        List<BlogViewModel> finalList = new List<BlogViewModel>();
                        foreach (var iblog in queryAll)
                        {
                            foreach (var jblog in blogViewModels)
                            {
                                if (iblog.Id == jblog.Id)
                                {
                                    finalList.Add(iblog);
                                }
                            }
                        }
                        return Json(finalList);
                    }
                    else
                    {
                        List<BlogViewModel> finalList = new List<BlogViewModel>();
                        var query = _dbContext.BlogEntities
                            .Where(x => x.BlogCategoryId == categoryId)
                            .Where(x => x.IsDeleted == false)
                            .Where(x => x.Status == 1)
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
                                CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                            })
                            .ToList();
                        foreach (var iblog in query)
                        {
                            foreach (var jblog in blogViewModels)
                            {
                                if (iblog.Id == jblog.Id)
                                {
                                    finalList.Add(iblog);
                                }
                            }
                        }
                        return Json(finalList);
                    }
                }
            }
            if (title != null)
            {
                if (categoryId == 0)
                {
                    var queryAll = _dbContext.BlogEntities
                        .Where(x => x.IsDeleted == false)
                        .Where(x => x.Status == 1)
                        .Where(x => x.Title.ToLower().Contains(title.ToLower()))
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
                            CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                        })
                        .ToList();
                    return Json(queryAll);
                }
                var query = _dbContext.BlogEntities
                    .Where(x => x.BlogCategoryId == categoryId)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
                    .Where(x => x.Title.ToLower().Contains(title.ToLower()))
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
                        CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                    })
                    .ToList();
                return Json(query);
            }
            else
            {
                if (categoryId == 0)
                {
                    var queryAll = _dbContext.BlogEntities
                        .Where(x => x.IsDeleted == false)
                        .Where(x => x.Status == 1)
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
                            CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                        })
                        .ToList();
                    return Json(queryAll);
                }
                var query = _dbContext.BlogEntities
                    .Where(x => x.BlogCategoryId == categoryId)
                    .Where(x => x.IsDeleted == false)
                    .Where(x => x.Status == 1)
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
                        CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                    })
                    .ToList();
                return Json(query);
            }

        }
        public IActionResult GetRecentNews()
        {
            var query = _dbContext.BlogEntities
                .Where(x => x.Status == 1)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(x => x.CreateDate)
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
                    CustomDate = x.CreateDate.ToString("MMMM dd, yyyy")
                })
                .ToList();
            return Json(query);
        }

        public IActionResult GetRelatedPosts(int categoryId, int thisBlogId)
        {
            var query = _dbContext.BlogEntities
                .Where(x => x.BlogCategoryId == categoryId)
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .Where(x => x.Id != thisBlogId)
                .Select(x => new BlogViewModel()
                {
                    Id = x.Id,
                    BlogCategoryId = x.BlogCategoryId,
                    CustomDate = x.CreateDate.ToString("MMMM dd, yyyy"),
                    Comments = x.Comments,
                    Title = x.Title,
                    Summary = x.Summary,
                    ImagePath = x.ImagePath
                })
                .ToList();
            return Json(query);
        }

        public IActionResult GetBlogTags()
        {
            var query = _dbContext.BlogTagsEntities
                .Where(x => x.IsDeleted == false)
                .Where(x => x.Status == 1)
                .ToList();
            return Json(query);
        }
    }
}
