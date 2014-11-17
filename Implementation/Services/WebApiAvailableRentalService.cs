using System;
using System.Collections;
using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.Properties;
using Cares.Models.ReportModels;
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
        private readonly IChaufferChargeRepository chaufferChargeRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WebApiAvailableRentalService(IChaufferChargeRepository chaufferChargeRepository, IHireGroupDetailRepository hireGroupDetailRepository, IVehicleRepository vehicleRepository, IInsuranceRtRepository insuranceRtRepository)
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
            
            this.hireGroupDetailRepository = hireGroupDetailRepository;
            this.vehicleRepository = vehicleRepository;
            this.insuranceRtRepository = insuranceRtRepository;
            this.chaufferChargeRepository = chaufferChargeRepository;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get Avialable Vehicles on the location for the given time duration
        /// </summary>
        public IEnumerable<WebApiAvailableHireGroupsApiResponse> GetAvailableHireGroupsWithRates(long operationWorkplaceId, DateTime startDateTime,
            DateTime endDateTime, long domainKey)
        {
           return hireGroupDetailRepository.GetAvailableVehicleInfoForWebApi(operationWorkplaceId, startDateTime, endDateTime, domainKey);
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<WebApiAvailableChauffer> GetAvailableServicesWithRates(long operationWorkplaceId, DateTime startDateTime, DateTime endDateTime,
       long domainKey, long hireGroupDetailId, string tarrifTypeCode)
        {
            IEnumerable<WebApiAvailableInsurance> insurances = insuranceRtRepository.GetAvailableInsuranceRtForWebApi(tarrifTypeCode, startDateTime, domainKey);
            IEnumerable<WebApiAvailableChauffer> availableChauffeurForWebApi =
            chaufferChargeRepository.GetAvailableChauffeurForWebApi(tarrifTypeCode, startDateTime,endDateTime, domainKey);
            return availableChauffeurForWebApi;
        }



        #endregion
    }
}
