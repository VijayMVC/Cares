using System.Web.Mvc;

namespace Cares.Web.Areas.EmployeeManagement.Controllers
{
    /// <summary>
    /// Designation Grade Controller
    /// </summary>
    public class DesignationGradeController : Controller
    {
        // GET: EmployeeManagement
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Designation Grade Area
        /// </summary>
        public ActionResult DesignGrade()
        {
            return View();
        }

        /// <summary>
        ///Employee Status Area
        /// </summary>
        public ActionResult EmployeeStatus()
        {
            return View();
        }

        /// <summary>
        ///Designation Area
        /// </summary>
        public ActionResult Designation()
        {
            return View();
        }
    }
}