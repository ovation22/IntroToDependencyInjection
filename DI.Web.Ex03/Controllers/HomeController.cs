using System.Web.Mvc;
using DI.Web.Ex03.Services;

namespace DI.Web.Ex03.Controllers
{
    public class HomeController : Controller
    {
        private readonly SampleService _service;

        public HomeController()
        {
            _service = new SampleService();
        }

        public ActionResult Index()
        {
            ViewBag.Message = _service.GetMessage(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _service.GetMessage(2);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = _service.GetMessage(3);

            return View();
        }
    }
}