using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Standard Rate Main Repository
    /// </summary>
    public sealed class StandardRateMainRepository : BaseRepository<StandardRateMain>, IStandardRateMainRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public StandardRateMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<StandardRateMain> DbSet
        {
            get
            {
                return db.StandardRateMains;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Standard Rates Main for User Domain Key
        /// </summary>
        public override IQueryable<StandardRateMain> GetAll()
        {
            return DbSet.Where(department => department.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
