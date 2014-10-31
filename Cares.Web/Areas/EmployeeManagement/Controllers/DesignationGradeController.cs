using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.EmployeeManagement.Controllers
{
    /// <summary>
    /// Designation Grade Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "Employee")]
    public class DesignationGradeController : BaseController
    {
        // GET: EmployeeManagement
        [SiteAuthorize(PermissionKey = "Employee")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Designation Grade Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "DesignGrade")]
        public ActionResult DesignGrade()
        {
            return View();
        }

        /// <summary>
        ///Employee Status Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "EmployeeStatus")]
        public ActionResult EmployeeStatus()
        {
            return View();
        }

        /// <summary>
        ///Designation Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "Designation")]
        public ActionResult Designation()
        {
            return View();
        }


        /// <summary>
        /// Job Type Area
        /// </summary>
        [SiteAuthorize(PermissionKey = "JobType")]
        public ActionResult JobType()
        {
            return View();
        }
    }
}