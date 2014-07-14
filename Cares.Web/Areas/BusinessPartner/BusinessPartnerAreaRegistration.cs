using System.Web.Mvc;

namespace Cares.Web.Areas.BusinessPartner
{
    public class BusinessPartnerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BusinessPartner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BusinessPartner_default",
                "BusinessPartner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}