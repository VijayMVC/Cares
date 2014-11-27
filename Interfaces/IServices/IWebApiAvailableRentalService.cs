using Cares.Models.ResponseModels;
using System;
using System.Collections.Generic;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Web Api Service for getting available items for Rental
    /// </summary>
    public interface IWebApiAvailableRentalService
    {
        /// <summary>
        /// Get available Hire groups with rates for given location and duration
        /// </summary>
        IEnumerable<WebApiAvailableHireGroupsApiResponse> GetAvailableHireGroupsWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey );

        /// <summary>
        /// Get available Services with rates for given location and duration
        /// </summary>
        IEnumerable<WebApiAvailableChauffer> GetAvailableChauffersWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey, long hireGroupDetailId, string tarrifTypeCode);


        /// <summary>
        /// Get avilable chauffers with rates
        /// </summary>
        IEnumerable<WebApiAdditionalDriverResponse> GetAdditionalDriverWithRates(
            long domainKey, string tarrifTypeCode);

        /// <summary>
        /// Get avilable Insurences with rates
        /// </summary>
        IEnumerable<WebApiAvailableInsurance> GetAvailableInsurencesWithRates(long domainKey, string tarrifTypeCode,
            DateTime startDateTime);

     

    }
}
