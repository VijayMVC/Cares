using System.Web.Mvc;

namespace Cares.Web.Areas.RentalAgreement
{
    public class RentalAgreementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RentalAgreement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RentalAgreement_default",
                "RentalAgreement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}