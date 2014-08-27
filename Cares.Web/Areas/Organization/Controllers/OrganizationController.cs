using System.Web.Mvc;

namespace Cares.Web.Areas.Organization.Controllers
{
    /// <summary>
    /// Organization Controller
    /// </summary>
    public class OrganizationController : Controller
    {
        /// <summary>
        /// Organization Group Area
        /// </summary>
        public ActionResult OrganizationGroup()
        {
            return View();
        }

        /// <summary>
        /// Company Area
        /// </summary>
        public ActionResult Company()
        {
            return View();
        }

        /// <summary>
        /// Department Area
        /// </summary>
        public ActionResult Department()
        {
            return View();
        }

        /// <summary>
        /// Operation Area
        /// </summary>
        public ActionResult Operation()
        {
            return View();
        }
    }
}