using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner InType Repository Interface
    /// </summary>
    public interface IBusinessPartnerInTypeRepository : IBaseRepository<BusinessPartnerInType, long>
    {
        /// <summary>
        /// Get business partner intype by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BusinessPartnerInType GetById(long id);
    }
}
