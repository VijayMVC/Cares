using System.Web.Mvc;

namespace Cares.Web.Areas.FleetPool
{
    public class FleetPoolAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FleetPool";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FleetPool_default",
                "FleetPool/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}