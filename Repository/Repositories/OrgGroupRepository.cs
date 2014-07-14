using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
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
            return DbSet.Where(orgGroup => orgGroup.UserDomainKey == UserDomaingKey);
        }
        #endregion

        
    }
}
