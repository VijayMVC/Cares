using Cares.Models.DomainModels;
using System.Collections.Generic;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Legal Status Service Interface
    /// </summary>
    public interface IBusinessLegalStatusService
    {
        /// <summary>
        /// Get all business legal status records
        /// </summary>
        IEnumerable<BusinessLegalStatus> LoadAll();

        /// <summary>
        /// Delete Business Legal Status
        /// </summary>
        void DeleteBusinessLegalStatus(long businessLegalStatusId);


        /// <summary>
        /// Search  Business Legal Status
        /// </summary>
        BusinessLegalStatusSearchRequestRespose SearchBusinessLegalStatus(BusinessLegalStatusSearchRequest request);

        /// <summary>
        /// Add / Update Business Legal Status
        /// </summary>
        BusinessLegalStatus AddUpdateBusinessLegalStatus(BusinessLegalStatus businessLegalStatusRequest);
    }
}
