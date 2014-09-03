using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Depreciation Repository
    /// </summary>
    public class VehicleDepreciationRepository : BaseRepository<VehicleDepreciation>, IVehicleDepreciationRepository
    {
          #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleDepreciationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleDepreciation> DbSet
        {
            get
            {
                return db.VehicleDepreciations;
            }
        }
        #endregion
    }
}
