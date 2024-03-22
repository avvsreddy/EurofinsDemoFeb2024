using System.Web.Mvc;

namespace HelloWorldWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // .../home/hello
        public ActionResult Hello()
        {
            string msg = "Hello, Welcome to my first mvc application";
            ViewBag.Message = msg;
            return View();
        }
    }
}