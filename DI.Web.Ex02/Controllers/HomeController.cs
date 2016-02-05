using System.Web.Mvc;
using DI.Web.Ex02.Services;

namespace DI.Web.Ex02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = new SampleService();

            ViewBag.Message = service.GetMessage(1);

            return View();
        }

        public ActionResult About()
        {
            var service = new SampleService();

            ViewBag.Message = service.GetMessage(2);

            return View();
        }

        public ActionResult Contact()
        {
            var service = new SampleService();

            ViewBag.Message = service.GetMessage(3);

            return View();
        }
    }
}