using System.Web.Mvc;

namespace Cares.Web.Areas.GeographicalHierarchy.Controllers
{
    /// <summary>
    /// Geographical Hierarchy Controller
    /// </summary>
    [Authorize]
    public class GeographicalHierarchyController : Controller
    {
        
        /// <summary>
        /// Region Area
        /// </summary>
        [Authorize]
        public ActionResult Region()
        {
            return View();
        }

        /// <summary>
        /// Sub-Region Area
        /// </summary>
        public ActionResult SubRegion()
        {
            return View();
        }

        /// <summary>
        /// City Area
        /// </summary>
        public ActionResult City()
        {
            return View();
        }

        /// <summary>
        /// Area Area  :)
        /// </summary>
        public ActionResult Area()
        {
            return View();
        }
    }
}