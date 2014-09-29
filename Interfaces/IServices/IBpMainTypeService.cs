
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    ///Business Partner Main Type Service Interface
    /// </summary>
    public interface IBpMainTypeService
    {
        /// <summary>
        /// Search Business Partner Main Type
        /// </summary>
        BpMainTypeSearchRequestResponse SearchBpMainType(BpMainTypeSearchRequest request);

        /// <summary>
        /// Delete Business Partner Main Type by id
        /// </summary>
        void DeleteBpMainType(long bpMainTypeId);

        /// <summary>
        /// Add /Update Business Partner Main Type
        /// </summary>
        BusinessPartnerMainType SaveBpMainType(BusinessPartnerMainType bpMainType);

    }
}
