using KnowledgeHubPortal.WebApplication.Models.Data;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KnowledgeHubPortal.WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : Controller
    {
        KnowledgeHubDbContext dbContext = new KnowledgeHubDbContext(); // use DIP
        // GET: Categories
        [AllowAnonymous]
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

        // async
        // await

        public async Task<ActionResult> IndexAsync()
        {
            // line 1
            // 2
            //3



            var categories = await dbContext.Categories.ToListAsync();
            //
            //
            //
            //


            //pass the data to view
            return View(categories);
        }


        [HttpGet]
        public ActionResult Create()
        {
            // return a view for collecting category info from the user
            return View(new Category());
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(Category category)
        {
            // Validate the input data
            if (!ModelState.IsValid)
            {
                return View(new Category());
            }
            // if its invalid - send the form with error message
            // if its valid - send the data to back end for saving



            if (category.CategoryID == 0) //new category
            {
                dbContext.Categories.Add(category);
                TempData["Message"] = $"{category.CategoryName} is successfully created!";
            }
            else // existing category - need to modify
            {
                dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                TempData["Message"] = $"{category.CategoryName} is successfully modified!";
            }

            dbContext.SaveChanges();

            //var categories = dbContext.Categories.ToList();

            // return a view
            //return View("Index",categories);

            //ViewBag.Message = msg;

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrUpdateAsync(Category category)
        {
            // Validate the input data
            if (!ModelState.IsValid)
            {
                return View(new Category());
            }
            // if its invalid - send the form with error message
            // if its valid - send the data to back end for saving



            if (category.CategoryID == 0) //new category
            {
                dbContext.Categories.Add(category);
                TempData["Message"] = $"{category.CategoryName} is successfully created!";
            }
            else // existing category - need to modify
            {
                dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                TempData["Message"] = $"{category.CategoryName} is successfully modified!";
            }

            await dbContext.SaveChangesAsync();

            //var categories = dbContext.Categories.ToList();

            // return a view
            //return View("Index",categories);

            //ViewBag.Message = msg;

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            // fetch the category by id
            Category categoryToDel = await dbContext.Categories.FindAsync(id);
            if (categoryToDel != null)
            {
                return View(categoryToDel);
                //dbContext.Categories.Remove(categoryToDel);
                //dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult ConfirmDelete(int id)
        {
            Category categoryToDel = dbContext.Categories.Find(id);
            if (categoryToDel != null)
            {
                //return View(categoryToDel);
                dbContext.Categories.Remove(categoryToDel);
                dbContext.SaveChanges();
            }
            string msg = $"{categoryToDel.CategoryName} is successfully deleted!";
            //ViewBag.Message = msg;
            TempData["Message"] = msg;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category categoryToEdit = dbContext.Categories.Find(id);
            if (categoryToEdit != null)
            {
                return View(categoryToEdit);
                //dbContext.Categories.Remove(categoryToDel);
                //dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Edit(Category category)
        //{
        //    // Validate the input data
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    // if its invalid - send the form with error message
        //    // if its valid - send the data to back end for saving

        //    //dbContext.Categories.Add(category);
        //    dbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
        //    dbContext.SaveChanges();

        //    //var categories = dbContext.Categories.ToList();

        //    // return a view
        //    //return View("Index",categories);
        //    string msg = $"{category.CategoryName} is successfully modified!";
        //    //ViewBag.Message = msg;
        //    TempData["Message"] = msg;
        //    return RedirectToAction("Index");
        //}
    }
}