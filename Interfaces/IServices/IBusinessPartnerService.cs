using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Partner Service Interface
    /// </summary>
    public interface IBusinessPartnerService
    {
        /// <summary>
        /// Get all business partneres
        /// </summary>
        BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        /// <summary>
        /// Delete businsess partner
        /// </summary>
        void DeleteBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Add business partner
        /// </summary>
        bool AddBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Update business partner
        /// </summary>
        bool UpdateBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Get business partnere by Id
        /// </summary>
        BusinessPartner FindBusinessPartnerById(long id);      
    }
}
