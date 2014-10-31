using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.BusinessPartner.Controllers
{
    /// <summary>
    /// Business Partner Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "BusinessPartner")]
    public class HomeController : BaseController
    {
        /// <summary>
        /// Business Partner Home Controller
        /// </summary>
        [SiteAuthorize(PermissionKey = "BusinessPartner")]
        public ActionResult Index()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessPartner")]
        public ActionResult DocumentGroup()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessPartnerMainType")]
        public ActionResult BusinessPartnerMainType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "Document")]
        public ActionResult Document()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessPartner")]
        public ActionResult RatingType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessLegalStatus")]
        public ActionResult BusinessLegalStatus()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "OccupationType")]
        public ActionResult OccupationType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessPartner")]
        public ActionResult RelationType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "BusinessPartnerSubType")]
        public ActionResult BusinessPartnerSubType()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "CreditLimit")]
        public ActionResult CreditLimit()
        {
            return View();
        }
        [SiteAuthorize(PermissionKey = "MarketingChannel")]
        public ActionResult MarketingChannel()
        {
            return View();
        }
	}
}