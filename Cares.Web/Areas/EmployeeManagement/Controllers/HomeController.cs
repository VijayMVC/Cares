using System.Web.Mvc;

namespace Cares.Web.Areas.EmployeeManagement.Controllers
{
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        // GET: EmployeeManagement/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}