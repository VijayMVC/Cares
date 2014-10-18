using System.Web.Mvc;

namespace Cares.Web.Areas.NonRevenueTicket.Controllers
{
    /// <summary>
    /// Non Revenue Ticket Area Controller
    /// </summary>
    public class NonRevenueTicketController : Controller
    {
        // GET: NonRevenueTicket/NonRevenueTicket
        public ActionResult NrtType()
        {
            return View();
        }

        // GET: NonRevenueTicket/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: NonRevenueTicket/NrtQueue
        public ActionResult NrtQueue()
        {
            return View();
        }
    }
}