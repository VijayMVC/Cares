using System.Web.Mvc;

namespace Cares.Web.Areas.Pricing.Controllers
{
    /// <summary>
    /// tariff Controller
    /// </summary>
    public class tariffController : Controller
    {
        //
        // GET: /tariffType/tariff/
        public ActionResult Index()
        {
            return View();
        }//
        // GET: /tariff/TariffRate/
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