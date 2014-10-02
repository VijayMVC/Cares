using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Partner Sub Type Service
    /// </summary>
    public interface IBusinessPartnerSubTypeService
    {

        /// <summary>
        /// Load all  Business Partner Sub Types
        /// </summary>
        IEnumerable<BusinessPartnerSubType> LoadAll();

        /// <summary>
        /// Delete Docum Business Partner Sub Type
        /// </summary>
        void DeleteBusinessPartnerSubType(long businessPartnerSubTypeId);

        /// <summary>
        /// Load Base data of Business Partner Sub Type
        /// </summary>
        BusinessPartnerSubTypeBaseDataResponse LoadBusinessPartnerSubTypeBaseData();

        /// <summary>
        /// Search Busines sPartner Sub Type
        /// </summary>
        BusinessPartnerSubTypeSearchRequestResponse SearchBusinessPartnerSubType(BusinessPartnerSubTypeSearchRequest request);

        /// <summary>
        /// Add / Update Business Partner Sub Type
        /// </summary>
        BusinessPartnerSubType AddUpdateBusinessPartnerSubType(BusinessPartnerSubType businessPartnerSubType);
    }
}
