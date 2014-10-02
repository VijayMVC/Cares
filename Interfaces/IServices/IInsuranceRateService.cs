using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Insurance Rate Service Interface
    /// </summary>
    public interface IInsuranceRateService
    {
        /// <summary>
        /// Get Base Data
        /// </summary>
        InsuranceRateBaseResponse GetBaseData();
       
        /// <summary>
        /// Load Insurance Rates
        /// </summary>
        InsuranceRateSearchResponse LoadInsuranceRates(InsuranceRateSearchRequest request);
        
        /// <summary>
        /// Get Insurance Rate Detail
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        InsuranceRtDetailResponse GetInsuranceRtDetail(long insuranceRtMainId);
        
        /// <summary>
        /// Add/Edir Insurance Rate
        /// </summary>
        /// <param name="insuranceRtMain"></param>
        /// <returns></returns>
        InsuranceRtMainContent SaveInsuranceRate(InsuranceRtMain insuranceRtMain);
        
        /// <summary>
        /// Delete Insurance Rate
        /// </summary>
        /// <param name="insuranceRtMain"></param>
        /// 
        void DeleteInsuranceRate(InsuranceRtMain insuranceRtMain);
        
        /// <summary>
        /// Insurance Rate Main By ID
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        InsuranceRtMain FindById(long insuranceRtMainId);

        /// <summary>
        /// Calculate Insurance Charge for Ra Billing
        /// </summary>
        RaHireGroupInsurance CalculateCharge(DateTime raRecCreatedDate, DateTime stDate, DateTime eDate,
            long operationId,
            long hireGroupDetailId, short insuranceTypeId, List<TariffType> oTariffTypeList);

        /// <summary>
        /// Get All For RA
        /// </summary>
        IEnumerable<InsuranceRt> GetAllForRa();

    }
}
