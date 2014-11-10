using System;
using System.Collections;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.Properties;
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
        private readonly IInsuranceRtRepository insuranceRtRepository;
        private readonly IEmployeeRepository employeeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WebApiAvailableRentalService(IHireGroupDetailRepository hireGroupDetailRepository, IVehicleRepository vehicleRepository, IInsuranceRtRepository insuranceRtRepository)
        {
            if (hireGroupDetailRepository == null)
            {
                throw new ArgumentNullException("hireGroupDetailRepository");
            }
            if (vehicleRepository == null)
            {
                throw new ArgumentNullException("vehicleRepository");
            }
            if (insuranceRtRepository == null)
            {
                throw new ArgumentNullException("insuranceRtRepository");
            }
            if (employeeRepository == null)
            {
                throw new ArgumentNullException("employeeRepository");
            }
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.vehicleRepository = vehicleRepository;
            this.insuranceRtRepository = insuranceRtRepository;
            this.employeeRepository = employeeRepository;
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


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<WebApiAvailableServices> GetAvailableServicesWithRates(long operationWorkplaceId, DateTime startDateTime, DateTime endDateTime,
       long domainKey, long hireGroupDetailId)
        {

            IEnumerable<WebApiAvailableInsurance> insurances = insuranceRtRepository.GetAvailableInsuranceRtForWebApi(hireGroupDetailId, startDateTime, domainKey);
            //IEnumerable<WebApiAvailableInsurance> insurances = employeeRepository.GetAllChauffers(operationWorkplaceId, startDateTime, endDateTime, domainKey);
            return null;
        }

        #endregion
    }
}
