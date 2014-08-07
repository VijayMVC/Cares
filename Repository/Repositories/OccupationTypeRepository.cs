using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
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
