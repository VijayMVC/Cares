using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Organization.Controllers
{
    /// <summary>
    /// Organization Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "OrgSetup")]
    public class OrganizationController : BaseController
    {
        /// <summary>
        /// Organization Group Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "OrganizationGroup")]
        public ActionResult OrganizationGroup()
        {
            return View();
        }

        /// <summary>
        /// Company Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Company")]
        public ActionResult Company()
        {
            return View();
        }

        /// <summary>
        /// Department Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Department")]
        public ActionResult Department()
        {
            return View();
        }

        /// <summary>
        /// Operation Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Operation")]
        public ActionResult Operation()
        {
            return View();
        }

        /// <summary>
        /// Operation Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Workplace")]
        public ActionResult Workplace()
        {
            return View();
        }

        /// <summary>
        /// Work Location Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "WorkLocation")]
        public ActionResult WorkLocation()
        {
            return View();
        }

        /// <summary>
        /// WorkplaceType Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "WorkplaceType")]
        public ActionResult WorkplaceType()
        {
            return View();
        }

        /// <summary>
        /// Business Segment Area
        /// </summary>
        /// <returns></returns>
        [SiteAuthorize(PermissionKey = "BusinessSegment")]
        public ActionResult BusinessSegment()
        {
            return View();
        }

    }
}