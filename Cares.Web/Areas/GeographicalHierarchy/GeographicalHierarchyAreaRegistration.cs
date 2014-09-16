using System.Web.Mvc;

namespace Cares.Web.Areas.GeographicalHierarchy
{
    public class GeographicalHierarchyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GeographicalHierarchy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GeographicalHierarchy_default",
                "GeographicalHierarchy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}