using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Reports.Controllers
{
    [SiteAuthorize(PermissionKey = "Reports")]
    public class ReportController : BaseController
    {
        // GET: Reports/Report
        [SiteAuthorize(PermissionKey = "FleetReport")]
        public ActionResult FleetReport()
        {
            return View();
        }

        [SiteAuthorize(PermissionKey = "DailyActionReport")]
        public ActionResult DailyActionReport()
        {
            return View();
        }

        [SiteAuthorize(PermissionKey = "RentalAgreementReport")]
        public ActionResult RentalAgreementReport()
        {
            return View();
        }

        public ActionResult MissingHireGroupReport()
        {
            return View();
        }
        public ActionResult StandardRateReport()
        {
            return View();
        }
    }
}