using Cares.Models.DomainModels;
namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Relationship Repository Interface
    /// </summary>
    public interface IBusinessPartnerRelationshipRepository : IBaseRepository<BusinessPartnerRelationship, int>
    {
        /// <summary>
        /// Association check b/w Business Partner Relationship and Business Partner Relationship Type
        /// </summary>
        bool IsBusinessPartnerRelationshipAssociatedBusinessPartnerRelationshipType(long businessPartnerRelationshipId);
    }
}
