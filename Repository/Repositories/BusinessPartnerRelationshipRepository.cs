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
        public override IQueryable<BusinessPartnerRelationship> GetAll()
        {
            return DbSet.Where(businessPartnerRelationship => businessPartnerRelationship.UserDomainKey == UserDomainKey);
        }
        /// <summary>
        /// Get Business Partner Relationship Item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerRelationship Find(int id)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
