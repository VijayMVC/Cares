using System;
using System.Collections.Generic;
using Cares.Models.ResponseModels;

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
        IEnumerable<WebApiAvailaleHireGroup> GetAvailableHireGroupsWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey);

        /// <summary>
        /// Get available Services with rates for given location and duration
        /// </summary>
        IEnumerable<WebApiAvailableServices> GetAvailableServicesWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey, long hireGroupDetailId);

    }
}
