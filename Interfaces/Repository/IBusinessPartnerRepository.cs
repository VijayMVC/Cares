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
    }
}
