using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cares.Web.Areas.Reports.Controllers
{
    public class ReportController : Controller
    {
        // GET: Reports/Report
        public ActionResult FleetReport()
        {
            return View();
        }

        public ActionResult DailyActionReport()
        {
            return View();
        }

        public ActionResult RentalAgreementReport()
        {
            return View();
        }

        public ActionResult MissingHireGroupReport()
        {
            return View();
        }
    }
}