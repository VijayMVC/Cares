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
    /// Business Partner Relationship Type Repository
    /// </summary>
    public sealed class BusinessPartnerRelationshipTypeRepository : BaseRepository<BusinessPartnerRelationshipType>, IBusinessPartnerRelationshipTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRelationshipTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessPartnerRelationshipType> DbSet
        {
            get
            {
                return db.BusinessPartnerRelationshipTypes;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Business Partner Relationship Types for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessPartnerRelationshipType> GetAll()
        {
            return DbSet.Where(businessPartnerRelationshipType => businessPartnerRelationshipType.UserDomainKey == UserDomainKey).ToList();
        }    
        /// <summary>
        /// Get Business Partner Relationship Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerRelationshipType Find(int id)
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}
