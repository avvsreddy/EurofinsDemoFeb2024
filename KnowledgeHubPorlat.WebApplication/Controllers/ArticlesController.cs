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
            // Show only the articles which are apporved
            return View(db.Articles.ToList());
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
            article.IsApproved = false;
            // save
            db.Articles.Add(article);
            db.SaveChanges();
            // return a view
            TempData["Message"] = $"Article {article.Title} is submited for admin review";
            return RedirectToAction("Submit");
        }

        public ActionResult Review()
        {
            // get the non approved articles
            var articlesToReview = db.Articles.Include("Category").Where(a => a.IsApproved == false).ToList();
            return View(articlesToReview);
        }

        public ActionResult Approve(int[] articleIds)
        {
            // change the IsApproved property to true

            // get all articles based on articlesids
            foreach (var aid in articleIds)
            {
                var articleToApprove = db.Articles.Find(aid);
                articleToApprove.IsApproved = true;
            }
            db.SaveChanges();
            TempData["Message"] = $" {articleIds.Length} articles approved successfully";

            //return View("Review");
            return RedirectToAction("Review");
        }

        public ActionResult Reject(int[] articleIds)
        {
            // delete all the records
            foreach (var aid in articleIds)
            {
                var articleToDelete = db.Articles.Find(aid);
                db.Articles.Remove(articleToDelete);
            }
            db.SaveChanges();
            TempData["Message"] = $" {articleIds.Length} articles rejected successfully";

            //return View("Review");
            return RedirectToAction("Review");

        }
    }
}