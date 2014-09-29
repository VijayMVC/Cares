using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Main Type Mapper
    /// </summary>
    public static class BpMainTypeMapper
    {

        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.BpMainTypeSearchRequestResponse CreateFrom(this BpMainTypeSearchRequestResponse source)
        {
            return new Models.BpMainTypeSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                BpMainTypes = source.BpMainTypes.Select(city => city.CreateFrom())
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static BusinessPartnerMainType CreateFrom(this Models.BusinessPartnerMainType source)
        {
            return new BusinessPartnerMainType
            {
                BusinessPartnerMainTypeId = source.BusinessPartnerMainTypeId,
                BusinessPartnerMainTypeCode = source.BusinessPartnerMainTypeCode,
                BusinessPartnerMainTypeName = source.BusinessPartnerMainTypeName,
                BusinessPartnerMainTypeDescription = source.BusinessPartnerMainTypeDescription

            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.BusinessPartnerMainType CreateFrom(this BusinessPartnerMainType source)
        {
            return new Models.BusinessPartnerMainType
            {
                BusinessPartnerMainTypeId = source.BusinessPartnerMainTypeId,
                BusinessPartnerMainTypeCode = source.BusinessPartnerMainTypeCode,
                BusinessPartnerMainTypeName = source.BusinessPartnerMainTypeName,
                BusinessPartnerMainTypeDescription = source.BusinessPartnerMainTypeDescription

            };
        }
    }
}