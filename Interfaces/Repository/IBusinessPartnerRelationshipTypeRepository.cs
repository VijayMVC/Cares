using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Relationship Type Repository Interface
    /// </summary>
    public interface IBusinessPartnerRelationshipTypeRepository : IBaseRepository<BusinessPartnerRelationshipType, int>
    {
        /// <summary>
        /// Search Business Partner Relationship Type
        /// </summary>
        IEnumerable<BusinessPartnerRelationshipType> SearchBusinessPartnerRelationshipType(BusinessPartnerRelationTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// Self code deuplication check
        /// </summary>
        bool BusinessPartnerRelationshipTypeCodeDuplicationCheck(
            BusinessPartnerRelationshipType businessPartnerRelationshipType);
    }
}
