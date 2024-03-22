using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index() // display categories
        {
            // get the categories data from model

            List<Category> categories = new List<Category>();
            Category c1 = new Category { CategoryID = 1, CategoryName = "Education", CategoryDescription = "Education Description" };
            categories.Add(c1);
            Category c2 = new Category { CategoryID = 2, CategoryName = "Sports", CategoryDescription = "Sports Description" };
            categories.Add(c2);
            Category c3 = new Category { CategoryID = 3, CategoryName = "Tech", CategoryDescription = "Tech Description" };
            categories.Add(c3);
            Category c4 = new Category { CategoryID = 4, CategoryName = "Entertinement", CategoryDescription = "Entertinement Description" };
            categories.Add(c4);
            Category c5 = new Category { CategoryID = 5, CategoryName = "Politics", CategoryDescription = "Politics Description" };
            categories.Add(c5);
            Category c6 = new Category { CategoryID = 6, CategoryName = "Finance", CategoryDescription = "Finance Description" };
            categories.Add(c6);
            //pass the data to view
            return View(categories);
        }
    }
}