using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System.Linq;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        KnowledgeHubDbContext dbContext = new KnowledgeHubDbContext(); // use DIP
        // GET: Categories
        public ActionResult Index() // display categories
        {
            // get the categories data from model

            //List<Category> categories = new List<Category>();
            //Category c1 = new Category { CategoryID = 1, CategoryName = "Education", CategoryDescription = "Education Description" };
            //categories.Add(c1);
            //Category c2 = new Category { CategoryID = 2, CategoryName = "Sports", CategoryDescription = "Sports Description" };
            //categories.Add(c2);
            //Category c3 = new Category { CategoryID = 3, CategoryName = "Tech", CategoryDescription = "Tech Description" };
            //categories.Add(c3);
            //Category c4 = new Category { CategoryID = 4, CategoryName = "Entertinement", CategoryDescription = "Entertinement Description" };
            //categories.Add(c4);
            //Category c5 = new Category { CategoryID = 5, CategoryName = "Politics", CategoryDescription = "Politics Description" };
            //categories.Add(c5);
            //Category c6 = new Category { CategoryID = 6, CategoryName = "Finance", CategoryDescription = "Finance Description" };
            //categories.Add(c6);


            var categories = dbContext.Categories.ToList();

            //pass the data to view
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            // return a view for collecting category info from the user
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            // Validate the input data
            if (!ModelState.IsValid)
            {
                return View();
            }
            // if its invalid - send the form with error message
            // if its valid - send the data to back end for saving

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            //var categories = dbContext.Categories.ToList();

            // return a view
            //return View("Index",categories);
            return RedirectToAction("Index");
        }
    }
}