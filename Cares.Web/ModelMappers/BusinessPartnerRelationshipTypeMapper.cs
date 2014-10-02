using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Relationship Type Mapper
    /// </summary>
    public static class BusinessPartnerRelationshipTypeMapper
    {
        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static Models.BusinessPartnerRelationshipTypeDropDown CreateFrommm(this BusinessPartnerRelationshipType source)
        {
            return new Models.BusinessPartnerRelationshipTypeDropDown
            {
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                BusinessPartnerRelationshipTypeCodeName = source.BusinessPartnerRelationshpTypeCode + " - " + source.BusinessPartnerRelationshipTypeName
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.BusinessPartnerRelationshipType CreateFromm(this BusinessPartnerRelationshipType source)
        {
            return new Models.BusinessPartnerRelationshipType
            {
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                BusinessPartnerRelationshpTypeCode = source.BusinessPartnerRelationshpTypeCode,
                BusinessPartnerRelationshipTypeName = source.BusinessPartnerRelationshipTypeName,
                BusinessPartnerRelationshipTypeDescription = source.BusinessPartnerRelationshipTypeDescription
            };
        }


        /// <summary>
        /// Create from search response domain model
        /// </summary>
        public static Models.BusinessPartnerRelationTypeSearchRequestResponse CreateFrom(this BusinessPartnerRelationTypeSearchRequestResponse source)
        {
            return new Models.BusinessPartnerRelationTypeSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                BusinessPartnerRelationshipTypes = source.BusinessPartnerRelationshipTypes.Select(bPRelationType => bPRelationType.CreateFromm())
            };
        }

        /// <summary>
        ///  Create domain model from web model
        /// </summary>
        public static BusinessPartnerRelationshipType CreateFromm(this Models.BusinessPartnerRelationshipType source)
        {
            return new BusinessPartnerRelationshipType
            {
                BusinessPartnerRelationshipTypeId = source.BusinessPartnerRelationshipTypeId,
                BusinessPartnerRelationshpTypeCode = source.BusinessPartnerRelationshpTypeCode,
                BusinessPartnerRelationshipTypeName = source.BusinessPartnerRelationshipTypeName,
                BusinessPartnerRelationshipTypeDescription = source.BusinessPartnerRelationshipTypeDescription
            };
        }
    }
}