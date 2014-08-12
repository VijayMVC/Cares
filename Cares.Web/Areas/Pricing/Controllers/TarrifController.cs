using System.Web.Mvc;

namespace Cares.Web.Areas.Pricing.Controllers
{
    /// <summary>
    /// Tarrif Controller
    /// </summary>
    public class TarrifController : Controller
    {
        //
        // GET: /TarrifType/Tarrif/
        public ActionResult Index()
        {
            return View();
        }//
        // GET: /Tarrif/TariffRate/
        public ActionResult TariffRate()
        {
            return View();
        }
        public ActionResult test()
        {
            return View();
        }//
	}
}