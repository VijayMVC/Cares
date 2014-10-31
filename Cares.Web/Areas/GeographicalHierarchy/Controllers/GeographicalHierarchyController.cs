using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.GeographicalHierarchy.Controllers
{
    /// <summary>
    /// Geographical Hierarchy Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "GeographicalHierarchy")]
    public class GeographicalHierarchyController : BaseController
    {
        
        /// <summary>
        /// Region Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Region")]
        public ActionResult Region()
        {
            return View();
        }

        /// <summary>
        /// Sub-Region Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "SubRegion")]
        public ActionResult SubRegion()
        {
            return View();
        }

        /// <summary>
        /// City Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "City")]
        public ActionResult City()
        {
            return View();
        }

        /// <summary>
        /// Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Area")]
        public ActionResult Area()
        {
            return View();
        }
    }
}