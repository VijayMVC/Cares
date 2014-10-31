using System.Web.Mvc;
using Cares.Web.Controllers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.NonRevenueTicket.Controllers
{
    /// <summary>
    /// Non Revenue Ticket Area Controller
    /// </summary>
    [SiteAuthorize(PermissionKey = "NonRevenueTicket")]
    public class NonRevenueTicketController : BaseController
    {
        // GET: NonRevenueTicket/NonRevenueTicket
        [SiteAuthorize(PermissionKey = "NrtType")]
        public ActionResult NrtType()
        {
            return View();
        }

        // GET: NonRevenueTicket/Index
        [SiteAuthorize(PermissionKey = "NonRevenueTicket")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: NonRevenueTicket/NrtQueue
        [SiteAuthorize(PermissionKey = "NrtQueue")]
        public ActionResult NrtQueue()
        {
            return View();
        }
    }
}