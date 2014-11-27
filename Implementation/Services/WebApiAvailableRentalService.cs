using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.ResponseModels;
using System;
using System.Collections.Generic;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Service for getting data for Available Rental items (hiregroups, services, chauffeur etc)
    /// </summary>
    public sealed class WebApiAvailableRentalService : IWebApiAvailableRentalService
    {
        #region Private
        private readonly IHireGroupDetailRepository hireGroupDetailRepository;
        private readonly IInsuranceRtRepository insuranceRtRepository;
        private readonly IChaufferChargeRepository chaufferChargeRepository;
        private readonly IAdditionalDriverChargeRepository additionalDriverChargeRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WebApiAvailableRentalService(IAdditionalDriverChargeRepository additionalDriverChargeRepository,IChaufferChargeRepository chaufferChargeRepository, IHireGroupDetailRepository hireGroupDetailRepository,
            IInsuranceRtRepository insuranceRtRepository)
        {
            if (hireGroupDetailRepository == null)
            {
                throw new ArgumentNullException("hireGroupDetailRepository");
            }
           
            if (insuranceRtRepository == null)
            {
                throw new ArgumentNullException("insuranceRtRepository");
            }
            this.additionalDriverChargeRepository = additionalDriverChargeRepository;
            this.hireGroupDetailRepository = hireGroupDetailRepository;
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
           return hireGroupDetailRepository.GetAvailableHireGroupsForWebApi(operationWorkplaceId, startDateTime, endDateTime, domainKey);
        }



        /// <summary>
        /// Get avilable chauffers with rates
        /// </summary>
        public IEnumerable<WebApiAvailableChauffer> GetAvailableChauffersWithRates(long operationWorkplaceId, DateTime startDateTime, DateTime endDateTime,
       long domainKey, long hireGroupDetailId, string tarrifTypeCode)
        {
                       return 
            chaufferChargeRepository.GetAvailableChauffeurForWebApi(tarrifTypeCode, startDateTime,endDateTime, domainKey);
        }

        /// <summary>
        /// Get avilable chauffers with rates
        /// </summary>
        public IEnumerable<WebApiAdditionalDriverResponse> GetAdditionalDriverWithRates(long domainKey, string tarrifTypeCode)
        {
           return additionalDriverChargeRepository.GetAdditionalDriversForWebApi(tarrifTypeCode, domainKey);

        }

        /// <summary>
        /// Get avilable Insurences with rates
        /// </summary>
        public IEnumerable<WebApiAvailableInsurance> GetAvailableInsurencesWithRates(long domainKey, string tarrifTypeCode,
            DateTime startDateTime)
        {
            return insuranceRtRepository.GetAvailableInsuranceRtForWebApi(tarrifTypeCode, startDateTime, domainKey);
        }
        #endregion
    }
}
