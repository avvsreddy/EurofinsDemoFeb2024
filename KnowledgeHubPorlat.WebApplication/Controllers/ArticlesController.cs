using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class ArticlesController : Controller
    {
        KnowledgeHubDbContext db = new KnowledgeHubDbContext(); // DIP

        // GET: Articles
        public ActionResult Index() // Browsing Articles
        {
            return View();
        }
        [HttpGet]
        public ActionResult Submit()
        {
            // get the category info
            var categories = db.Categories.ToList();

            var selectListItems = categories.Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryID.ToString()
            });

            ViewBag.CategoryID = selectListItems;
            return View();
        }
        [HttpPost]
        public ActionResult Submit(Article article)
        {
            // validate
            if (!ModelState.IsValid)
            {
                return View();
            }
            // fill the remaining prop
            if (Request.IsAuthenticated)
            {
                article.PostedBy = User.Identity.Name;
            }
            else
            {
                article.PostedBy = "Unknown";
            }
            article.DatePosted = DateTime.Now;
            // save
            db.Articles.Add(article);
            db.SaveChanges();
            // return a view
            TempData["Message"] = $"Article {article.Title} is submited for admin review";
            return RedirectToAction("Submit");
        }
    }
}