using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Sub Type Repository Interface
    /// </summary>
    public interface IBpSubTypeRepository : IBaseRepository<BusinessPartnerSubType, int>
    {

        /// <summary>
        /// Association check between bp sub type and bp main type
        /// </summary>
       bool IsBpSubTypeAssociatedWithBpMainType(long bpMainTypeId);

    }
}

