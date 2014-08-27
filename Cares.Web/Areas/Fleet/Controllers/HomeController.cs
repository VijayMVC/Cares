using System.Web.Mvc;

namespace Cares.Web.Areas.Fleet.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /FleetPool/Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }
        //
        // GET: /HireGroup/Home/
        public ActionResult HireGroup()
        {
            return View();
        }
        public ActionResult Vehicle()
        {
            return View();
        }
	}
}