using System.Web.Mvc;

namespace Cares.Web.Areas.TarrifType
{
    public class TarrifTypeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TarrifType";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TarrifType_default",
                "TarrifType/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}