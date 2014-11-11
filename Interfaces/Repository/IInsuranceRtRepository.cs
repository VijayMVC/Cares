using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Insurance Rate Repository Interface
    /// </summary>
    public interface IInsuranceRtRepository : IBaseRepository<InsuranceRt, long>
    {
        /// <summary>
        /// Get Insurance Rate By Insurance Rate Main ID 
        /// </summary>
        /// <param name="insuranceRtMainId"></param>
        /// <returns></returns>
        IEnumerable<InsuranceRt> GetInsuranceRtByInsuranceRtMainId(long insuranceRtMainId);

        /// <summary>
        /// Get Insurance Rate For RA Billing 
        /// </summary>
        IEnumerable<InsuranceRt> GetForRaBilling(string tariffTypeCode, long hireGroupDetailId, long insuranceTypeId, DateTime raRecCreatedDate);

        /// <summary>
        /// Get All Insurance Rate For RA 
        /// </summary>
        IEnumerable<InsuranceRt> GetAllForRa();

        /// <summary>
        /// Association check B/W Insurance Type and Insurance RT
        /// </summary>
        bool IsInsuranceTypeAssociatedWithInsuranceRt(long insuranceTypeId);

        /// <summary>
        /// Get Available Insurance Rate ForWebApi
        /// </summary>
        IEnumerable<WebApiAvailableInsurance> GetAvailableInsuranceRtForWebApi(long hireGroupDetailId, DateTime startDt,
            long userDomainKey);

        /// <summary>
        /// Get Insurance Rate Report data
        /// </summary>
        /// <returns></returns>
        IEnumerable<InsuranceRateReportResponse> GetInsuranceRateReportData();


    }
}
