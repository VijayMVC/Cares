using System.Web.Mvc;

namespace Cares.Web.Areas.RentalAgreement.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Rental Agreement
        /// </summary>
        public ActionResult Index() 
        {
            return View();
        }

        /// <summary>
        /// Rental Agreement Queue
        /// </summary>
        public ActionResult RaQueue()
        {
            return View();
        }
	}
}