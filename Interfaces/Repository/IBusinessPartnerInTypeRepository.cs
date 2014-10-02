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
        BusinessPartnerInType GetById(long id);

        /// <summary>
        /// Association check of Business Partner Sub Type and Business Partner Sub Type
        /// </summary>
        bool IsBusinessPartnerSubTypeAssociatedWithBusinessPartnerInType(long businessPartnerSubTypeId);
    }
}
