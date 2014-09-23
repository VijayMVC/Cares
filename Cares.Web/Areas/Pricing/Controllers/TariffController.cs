using System.Web.Mvc;

namespace Cares.Web.Areas.Pricing.Controllers
{
    /// <summary>
    /// tariff Controller
    /// </summary>
    public class TariffController : Controller
    {
        //
        // GET: /TariffType/Tariff/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Tariff/TariffRate/
        public ActionResult TariffRate()
        {
            return View();
        }

        // GET: /Tariff/InsuranceRate/
        public ActionResult InsuranceRate()
        {
            return View();
        }

        // GET: /Tariff/ServiceRate/
        public ActionResult ServiceRate()
        {
            return View();
        }

        // GET: /Tariff/AdditionalDriver/
        public ActionResult AdditionalDriver()
        {
            return View();
        }

         /// <summary>
        /// Discount Type Area
       /// </summary>
        public ActionResult DiscountType()
        {
            return View();
        }
	}
}