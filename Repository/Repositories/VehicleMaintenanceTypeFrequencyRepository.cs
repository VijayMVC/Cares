using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Maintenance Type Frequency Repository
    /// </summary>
    public class VehicleMaintenanceTypeFrequencyRepository : BaseRepository<VehicleMaintenanceTypeFrequency>, IVehicleMaintenanceTypeFrequencyRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleMaintenanceTypeFrequencyRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleMaintenanceTypeFrequency> DbSet
        {
            get
            {
                return db.VehicleMaintenanceTypeFrequencies;
            }
        }
        #endregion
    }
}
