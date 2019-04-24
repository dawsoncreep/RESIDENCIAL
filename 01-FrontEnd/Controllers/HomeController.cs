using Common;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}