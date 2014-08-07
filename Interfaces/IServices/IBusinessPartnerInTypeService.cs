using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Partner InType Service Interface
    /// </summary>
    public interface IBusinessPartnerInTypeService
    {
        ///// <summary>
        ///// Get all business partneres
        ///// </summary>
        ///// <param name="businessPartnerSearchRequest"></param>
        ///// <returns></returns>
        //BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        
        ///// <summary>
        ///// Delete businsess partner individual
        ///// </summary>
        ///// <param name="businessPartner"></param>
        //void DeleteBusinessPartnerInType(BusinessPartnerInTypesPartner);
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
        /// Get business partner intype by business partner Id
        /// </summary>
        BusinessPartnerInType FindBusinessPartnerInTypeById(long id);
      
    }
}
