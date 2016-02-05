using System.Web.Mvc;
using DI.Web.Ex05.Services;

namespace DI.Web.Ex05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISampleService _service;

        public HomeController() : this(new SampleService())
        {
        }

        public HomeController(ISampleService service)
        {
            _service = service;
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