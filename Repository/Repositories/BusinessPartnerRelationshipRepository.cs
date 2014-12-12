using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Business Partner Relationship Repository
    /// </summary>
    public sealed class BusinessPartnerRelationshipRepository : BaseRepository<BusinessPartnerRelationship>, IBusinessPartnerRelationshipRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRelationshipRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerRelationship> DbSet
        {
            get
            {
                return db.BusinessPartnerRelationships;
            }
        }

        #endregion
        #region Public
        
        /// <summary>
        /// Get All Business Partner Relationship item list for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerRelationship> GetAll()
        {
            return DbSet.Where(businessPartnerRelationship => businessPartnerRelationship.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Business Partner Relationship Item by Id
        /// </summary>
        public BusinessPartnerRelationship Find(int id)
        {
            return DbSet.FirstOrDefault(businessPartnerRelationship => businessPartnerRelationship.BusinessPartnerRelationshipId == id && businessPartnerRelationship.UserDomainKey==UserDomainKey);
        }

        /// <summary>
        /// Association check b/w Business Partner Relationship and Business Partner Relationship Type
        /// </summary>
        public bool IsBusinessPartnerRelationshipAssociatedBusinessPartnerRelationshipType(long businessPartnerRelationshipId)
        {
            return
                DbSet.Count(
                    bPrelationship =>bPrelationship.UserDomainKey== UserDomainKey &&  bPrelationship.BusinessPartnerRelationshipTypeId == businessPartnerRelationshipId) >
                0;
        }
        #endregion
    }
}
