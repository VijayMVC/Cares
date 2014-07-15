using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Models.RequestModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// FleetPool Repository
    /// </summary>
    public sealed class FleetPoolRepository:BaseRepository<FleetPool>, IFleetPoolRepository
    {
        #region Public
        /// <summary>
        /// Get All FleetPools for User Domain Key
        /// </summary>
        public IQueryable<FleetPool> GetAll(FleetPoolSearchRequest searchRequest)
        {
            return DbSet.Where(x => x.UserDomainKey == UserDomaingKey);
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FleetPoolRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<FleetPool> DbSet
        {
            get
            {
                return db.FleetPools;
            }
        }

        #endregion
    }
}
