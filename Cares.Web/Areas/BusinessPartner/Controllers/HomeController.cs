using System.Web.Mvc;

namespace Cares.Web.Areas.BusinessPartner.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Business Partner Home Controller
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DocumentGroup()
        {
            return View();
        }
        public ActionResult BusinessPartnerMainType()
        {
            return View();
        }
        public ActionResult Document()
        {
            return View();
        }

        public ActionResult RatingType()
        {
            return View();
        }

        public ActionResult BusinessLegalStatus()
        {
            return View();
        }

        public ActionResult OccupationType()
        {
            return View();
        }
        public ActionResult RelationType()
        {
            return View();
        }
        public ActionResult BusinessPartnerSubType()
        {
            return View();
        }
	}
}