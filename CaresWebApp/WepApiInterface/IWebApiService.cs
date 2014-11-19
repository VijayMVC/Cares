using Cares.WebApp.Models;
using Cares.WebApp.RequestModels;

namespace Cares.WebApp.WepApiInterface
{
    /// <summary>
    /// Web Api Service Interface
    /// </summary>
    public interface IWebApiService
    {

        /// <summary>
        /// Get Operation Workplace List
        /// </summary>
        GetOperationWorkplaceResult GetOperationWorkplaceList(long domainKey);

        /// <summary>
        /// Get Hire Group List
        /// </summary>
        GetHireGroupResult GetHireGroupList(GetHireGroupRequest request);

        /// <summary>
        /// Get Services List
        /// </summary>
        GetServicesResult GetServicesList(AvailableServicesRequest request);

        /// <summary>
        /// Get Available Insurances Rates 
        /// </summary>
        GetAvailableInsurancesRatesResults GetAvailableInsurancesRates(WebApiRequest webApiRequest);

        GetAvailableCahuffersRatesResults GetAvailableChauffersRates(WebApiRequest webApiRequest);
        GetAdditionalDriverRatesResults GetAdditionalDriverRates(WebApiRequest webApiRequest);


    }
}
