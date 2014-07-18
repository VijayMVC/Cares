using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Business Partner Service Interface
    /// </summary>
    public interface IBusinessPartnerService
    {
        /// <summary>
        /// Get all business partneres
        /// </summary>
        /// <param name="businessPartnerSearchRequest"></param>
        /// <returns></returns>
        BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        /// <summary>
        /// Delete businsess partner
        /// </summary>
        /// <param name="businessPartner"></param>
        void DeleteBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Add business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        bool AddBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Update business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        bool UpdateBusinessPartner(BusinessPartner businessPartner);
        /// <summary>
        /// Get business partnere by Id
        /// </summary>
        BusinessPartner FindBusinessPartnerById(long id);
      
    }
}
