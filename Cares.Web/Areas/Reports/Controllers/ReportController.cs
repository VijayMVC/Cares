using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Reports.Controllers
{
    [SiteAuthorize(PermissionKey = "Reports")]
    public class ReportController : BaseController
    {
        // GET: Reports/Report
        [SiteAuthorize(PermissionKey = "FleetPoolReport")]
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

         [SiteAuthorize(PermissionKey = "MissingHireGroupReport")]
        public ActionResult MissingHireGroupReport()
        {
            return View();
        }

         [SiteAuthorize(PermissionKey = "StandardRateReport")]
        public ActionResult StandardRateReport()
        {
            return View();
        }

         public ActionResult InsuranceRateReport()
         {
             return View();
         }

         public ActionResult GrossSalesReport()
         {
             return View();
         }


    }
}