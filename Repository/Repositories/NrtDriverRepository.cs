using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nrt Diver Repository
    /// </summary>
    public class NrtDriverRepository : BaseRepository<NrtDriver>, INrtDriverRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtDriverRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtDriver> DbSet
        {
            get
            {
                return db.NrtDrivers;
            }
        }
        #endregion
    }
}
