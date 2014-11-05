using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.RentalAgreement.Controllers
{
    /// <summary>
    /// Rental Agreement Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "RentalAgreement")]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Rental Agreement
        /// </summary>
        [SiteAuthorize(PermissionKey = "RentalAgreement")]
        public ActionResult Index() 
        {
            return View();
        }

        /// <summary>
        /// Rental Agreement Queue
        /// </summary>
        [SiteAuthorize(PermissionKey = "RaQueue")]
        public ActionResult RaQueue()
        {
            return View();
        }
	}
}