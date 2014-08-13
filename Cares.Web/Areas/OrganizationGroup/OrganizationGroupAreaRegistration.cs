using System.Web.Mvc;

namespace Cares.Web.Areas.OrganizationGroup
{
    public class OrganizationGroupAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OrganizationGroup";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OrganizationGroup_default",
                "OrganizationGroup/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}