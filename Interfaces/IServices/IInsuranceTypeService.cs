using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Insurance Type Service Interface
    /// </summary>
    public interface IInsuranceTypeService
    {
        /// <summary>
        /// Get All For RA
        /// </summary>
        IEnumerable<InsuranceType> GetAllForRa();

        /// <summary>
        /// Delete Insurance Type
        /// </summary>
        void DeleteInsuranceType(long insuranceTypeId);

        /// <summary>
        /// Search Insurance Type
        /// </summary>
        InsuranceTypeSearchRequestResponse SearchInsuranceType(InsuranceTypeSearchRequest request);

        /// <summary>
        /// Add / Update Insurance Type
        /// </summary>
        InsuranceType AddUpdateInsuranceType(InsuranceType insuranceType);
    }

}

