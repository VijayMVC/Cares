using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Pricing.Controllers
{
    /// <summary>
    /// tariff Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "Pricing")]
    public class TariffController : BaseController
    {
        //
        // GET: /TariffType/Tariff/
        [SiteAuthorize(PermissionKey = "TariffType")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Tariff/TariffRate/
        [SiteAuthorize(PermissionKey = "TariffRate")]
        public ActionResult TariffRate()
        {
            return View();
        }

        // GET: /Tariff/InsuranceRate/
        [SiteAuthorize(PermissionKey = "InsuranceRate")]
        public ActionResult InsuranceRate()
        {
            return View();
        }

        // GET: /Tariff/ServiceRate/
        [SiteAuthorize(PermissionKey = "ServiceRate")]
        public ActionResult ServiceRate()
        {
            return View();
        }

        // GET: /Tariff/AdditionalDriver/
        [SiteAuthorize(PermissionKey = "AdditionalDriver")]
        public ActionResult AdditionalDriver()
        {
            return View();
        }

        // GET: /Tariff/AdditionalCharge/
        [SiteAuthorize(PermissionKey = "AdditionalCharge")]
        public ActionResult AdditionalCharge()
        {
            return View();
        }
        
         /// <summary>
        /// Discount Type Area
       /// </summary>
       [SiteAuthorize(PermissionKey = "DiscountType")]
        public ActionResult DiscountType()
        {
            return View();
        }

        /// <summary>
        /// Discount Sub Type
        /// </summary>
        [SiteAuthorize(PermissionKey = "DiscountSubType")]
        public ActionResult DiscountSubType()
        {
            return View();
        }

        /// <summary>
        /// Servce Type
        /// </summary>
        [SiteAuthorize(PermissionKey = "ServiceType")]
        public ActionResult ServiceType()
        {
            return View();
        }

        /// <summary>
        /// Chauffer Charge
        /// </summary>
        [SiteAuthorize(PermissionKey = "ChaufferCharge")]
        public ActionResult ChaufferCharge()
        {
            return View();
        }


        /// <summary>
        /// Seasonal Discount
        /// </summary>
        [SiteAuthorize(PermissionKey = "SeasonalDiscount")]
        public ActionResult SeasonalDiscount()
        {
            return View();
        }
        /// <summary>
        /// Service Item
        /// </summary>
        [SiteAuthorize(PermissionKey = "ServiceItem")]
        public ActionResult ServiceItem()
        {
            return View();
        }
	}
}