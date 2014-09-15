using System.Web.Mvc;

namespace Cares.Web.Areas.GeographicalHierarchy.Controllers
{
    /// <summary>
    /// Geographical Hierarchy Controller
    /// </summary>
    public class GeographicalHierarchyController : Controller
    {
        
        /// <summary>
        /// Region Area
        /// </summary>
        public ActionResult Region()
        {
            return View();
        }

        /// <summary>
        /// Sub region area
        /// </summary>
        public ActionResult SubRegion()
        {
            return View();
        }
    }
}