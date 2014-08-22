using System.Web.Mvc;

namespace Cares.Web.Areas.Operation.Controllers
{
    public  class HomeController : Controller
    {
        // GET: Operation/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}