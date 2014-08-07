using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;


namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Organization Group Repository
    /// </summary>
    public sealed class OrgGroupRepository : BaseRepository<OrgGroup>, IOrgGroupRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrgGroupRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OrgGroup> DbSet
        {
            get
            {
                return db.OrgGroups;
            }
        }

        #endregion
       
        #region Public
        /// <summary>
        /// Get All Organization Groups for User Domain Key
        /// </summary>
        public override IQueryable<OrgGroup> GetAll()
        {
            return DbSet.Where(orgGroup => orgGroup.UserDomainKey == UserDomainKey);
        }
        #endregion
        
    }
}
