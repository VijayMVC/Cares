using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Reservation Repository
    /// </summary>
    public class VehicleReservationRepository : BaseRepository<VehicleReservation>, IVehicleReservationRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleReservationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleReservation> DbSet
        {
            get
            {
                return db.VehicleReservations;
            }
        }
        #endregion
    }
}
