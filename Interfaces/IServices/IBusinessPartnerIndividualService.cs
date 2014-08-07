using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Partner Individual Service Interface
    /// </summary>
    public interface IBusinessPartnerIndividualService
    {
        ///// <summary>
        ///// Get all business partneres
        ///// </summary>
        ///// <param name="businessPartnerSearchRequest"></param>
        ///// <returns></returns>
        //BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        
        /// <summary>
        /// Delete businsess partner individual
        /// </summary>
        /// <param name="businessPartner"></param>
        void DeleteBusinessPartnerIndividual(BusinessPartnerIndividual businessPartner);
        ///// <summary>
        ///// Add business partner
        ///// </summary>
        ///// <param name="businessPartner"></param>
        ///// <returns></returns>
        //bool AddBusinessPartnerIndividual(BusinessPartnerIndividual businessPartner);
        ///// <summary>
        ///// Update business partner
        ///// </summary>
        ///// <param name="businessPartner"></param>
        ///// <returns></returns>
        //bool UpdateBusinessPartnerIndividual(BusinessPartnerIndividual businessPartner);
        /// <summary>
        /// Get business partnere by business partner Id
        /// </summary>
        BusinessPartnerIndividual FindBusinessPartnerIndividualById(long id);
      
    }
}
