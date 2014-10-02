using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner SubType Repository Interface
    /// </summary>
    public interface IBusinessPartnerSubTypeRepository : IBaseRepository<BusinessPartnerSubType, int>
    {
        /// <summary>
        /// Search Business Partner Sub Type
        /// </summary>
        IEnumerable<BusinessPartnerSubType> SearchBusinessPartnerSubType(BusinessPartnerSubTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// BusinessPartnerSubType Self code duplication check
        /// </summary>
        bool BusinessPartnerSubTypeCodeDuplicationCheck(BusinessPartnerSubType businessPartnerSubType);

        /// <summary>
        /// Load the detail object of Business Partner SubType
        /// </summary>
        BusinessPartnerSubType LoadBusinessPartnerSubTypeWithDetail(long businessPartnerSubTypeId);
    }
}
