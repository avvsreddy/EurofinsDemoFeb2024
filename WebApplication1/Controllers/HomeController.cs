using System;
using System.Threading;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        IProductRepo repo = null;// new ProductRepo();
        //public HomeController()
        //{
        //    repo = new ProductRepo();
        //}
        public HomeController(IProductRepo repo)
        {
            this.repo = repo;
        }
        public ActionResult Index()
        {



            return View();
        }
        [OutputCache(Duration = 60)]
        public ActionResult List()
        {
            //ProductRepo repo = new ProductRepo();
            var allProducts = repo.GetProducts();

            Thread.Sleep(10000);


            return View(allProducts);
        }
        public ActionResult About()
        {
            //try
            //{
            ViewBag.Message = "Your application description page.";
            throw new Exception("server error");
            return View();
            //}
            //catch(Exception ex)
            //{

            //}
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [OutputCache(Duration = 60 * 60, VaryByParam = "*", Location = System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Privacy(string p1, string p2)
        {
            ViewBag.Today = DateTime.Now;

            return View();
        }


        public ActionResult Test()
        {
            return View();
        }
    }
}