
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Partner  Relation  Type Service Interface
    /// </summary>
    public interface IBusinessPartnerRelationTypeService
    {

        /// <summary>
        /// Search Business Partner Relation Type
        /// </summary>
        BusinessPartnerRelationTypeSearchRequestResponse SearchBusinessPartnerRelationType(BusinessPartnerRelationTypeSearchRequest request);

        /// <summary>
        /// Delete Business Partner Relation Type by id
        /// </summary>
        void DeleteBusinessPartnerRelationType(long businessPartnerRelationTypeId);

        /// <summary>
        /// Add /Update Busines sPartner Relationship Type
        /// </summary>
        BusinessPartnerRelationshipType SaveBusinessPartnerRelationType(BusinessPartnerRelationshipType businessPartnerRelationshipType);

    }
}
