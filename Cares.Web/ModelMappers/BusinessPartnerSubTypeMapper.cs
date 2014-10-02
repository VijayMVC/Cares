using Cares.Web.Models;
using System.Linq;
using BusinessPartnerSubTypeBaseDataResponse = Cares.Models.ResponseModels.BusinessPartnerSubTypeBaseDataResponse;
using BusinessPartnerSubTypeSearchRequestResponse = Cares.Models.ResponseModels.BusinessPartnerSubTypeSearchRequestResponse;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Sub Type Mapper
    /// </summary>
    public static class BusinessPartnerSubTypeMapper
    {
        #region Public
        /// <summary>
        /// Crete From web model
        /// </summary>
        public static Cares.Models.DomainModels.BusinessPartnerSubType CreateFrom(this BusinessPartnerSubType source)
        {
            return new Cares.Models.DomainModels.BusinessPartnerSubType
            {
                BusinessPartnerMainTypeId = source.BusinessPartnerMainTypeId,
                BusinessPartnerSubTypeCode = source.BusinessPartnerSubTypeCode,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeName,
                BusinessPartnerSubTypeDescription = source.BusinessPartnerSubTypeDescription,
                BusinessPartnerSubTypeKey = source.BusinessPartnerSubTypeKey
            };
        }
        /// <summary>
        /// Crete From  Response domain model
        /// </summary>
        public static Models.BusinessPartnerSubTypeSearchRequestResponse CreateFrom(this BusinessPartnerSubTypeSearchRequestResponse source)
        {
            return new Models.BusinessPartnerSubTypeSearchRequestResponse
            {
                BusinessPartnerSubTypes = source.BusinessPartnerSubTypes.Select(businessPartnerSubType => businessPartnerSubType.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }
        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static BusinessPartnerSubType CreateFromm(this Cares.Models.DomainModels.BusinessPartnerSubType source)
        {
            return new BusinessPartnerSubType
            {
                BusinessPartnerMainTypeId = source.BusinessPartnerMainTypeId,
                BusinessPartnerMainTypeName = source.BusinessPartnerMainType.BusinessPartnerMainTypeName,
                BusinessPartnerSubTypeCode = source.BusinessPartnerSubTypeCode,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeName,
                BusinessPartnerSubTypeDescription = source.BusinessPartnerSubTypeDescription,
                BusinessPartnerSubTypeKey = source.BusinessPartnerSubTypeKey
            };
        }
       
        /// <summary>
        /// Crete From response model to web base data
        /// </summary>
        public static Models.BusinessPartnerSubTypeBaseDataResponse CreateFrom(this BusinessPartnerSubTypeBaseDataResponse source)
        {
            return new Models.BusinessPartnerSubTypeBaseDataResponse
            {
                BusinessPartnerMainTypeDropDown = source.BusinessPartnerMainType.Select(businessPartnerMainType => businessPartnerMainType.CreateFromm())
            };
        }
        #endregion
    }
}