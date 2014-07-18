using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.Repository
{
    /// <summary>
    /// Business Partner Repository Interface
    /// </summary>
    public interface IBusinessPartnerRepository : IBaseRepository<BusinessPartner, long>
    {
        /// <summary>
        /// Get All business partners
        /// </summary>
        /// <param name="businessPartnerSearchRequest"></param>
        /// <returns></returns>
        BusinessPartnerResponse GetAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        /// <summary>
        /// Get Busienss partner by Name and Id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        BusinessPartner GetBusinessPartnerByName(string name, int id);
        /// <summary>
        /// Get business partner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BusinessPartner GetById(long id);
    }
}
