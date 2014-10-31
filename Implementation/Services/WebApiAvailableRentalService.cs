using System;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Service for getting data for Available Rental items (hiregroups, services, chauffeur etc)
    /// </summary>
    public sealed class WebApiAvailableRentalService : IWebApiAvailableRentalService
    {
        #region Private
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IVehicleRepository vehicleRepository;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WebApiAvailableRentalService(IHireGroupDetailRepository hireGroupDetailRepository, IVehicleRepository vehicleRepository)
        {
            if (hireGroupDetailRepository == null)
            {
                throw new ArgumentNullException("hireGroupDetailRepository");
            }
            if (vehicleRepository == null)
            {
                throw new ArgumentNullException("vehicleRepository");
            }
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.vehicleRepository = vehicleRepository;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Avialable Vehicles on the location for the given time duration
        /// </summary>
        public IEnumerable<WebApiAvailaleHireGroup> GetAvailableHireGroupsWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey)
        {
            IEnumerable<long> availableHireGroups = hireGroupDetailRepository.GetAvailableVehicleInfoForWebApi(operationWorkplaceId, startDateTime, endDateTime, domainKey);

            IEnumerable<WebApiAvailaleHireGroup> vehicles = vehicleRepository.GetAvaibaleVehiclesForWebApi(availableHireGroups, domainKey);
            return vehicles;
        }
        #endregion
    }
}
