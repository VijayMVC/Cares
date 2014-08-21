using System.Web.Mvc;

namespace Cares.Web.Areas.Company.Controllers
{
    public class HomeController : Controller
    {
        // GET: Company/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}