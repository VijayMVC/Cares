using System.Web.Mvc;

namespace Cares.Web.Areas.NonRevenueTicket
{
    public class NonRevenueTicketAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NonRevenueTicket";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NonRevenueTicket_default",
                "NonRevenueTicket/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}