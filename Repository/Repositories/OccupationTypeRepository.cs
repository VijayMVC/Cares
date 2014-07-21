using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// Occupation Type Repository
    /// </summary>
    public sealed class OccupationTypeRepository : BaseRepository<OccupationType>, IOccupationTypeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OccupationTypeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<OccupationType> DbSet
        {
            get
            {
                return db.OccupationTypes;
            }
        }

        #endregion

        #region Public
        /// <summary>
        /// Get All Occupation Types for User Domain Key
        /// </summary>
        public override IQueryable<OccupationType> GetAll()
        {
            return DbSet.Where(occupationType => occupationType.UserDomainKey == UserDomainKey);
        }
        #endregion
    }
}
