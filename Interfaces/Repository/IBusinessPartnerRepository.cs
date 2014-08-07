using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Repository Interface
    /// </summary>
    public interface IBusinessPartnerRepository : IBaseRepository<BusinessPartner, long>
    {
        /// <summary>
        /// Get All business partners
        /// </summary>
        BusinessPartnerResponse GetAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        /// <summary>
        /// Get Busienss partner by Name and Id
        /// </summary>
        BusinessPartner GetBusinessPartnerByName(string name, int id);
        /// <summary>
        /// Get business partner by Id
        /// </summary>
        BusinessPartner GetById(long id);
    }
}
