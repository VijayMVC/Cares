using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Chauffer Reservation Repository
    /// </summary>
    public class ChaufferReservationRepository: BaseRepository<ChaufferReservation>, IChaufferReservationRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ChaufferReservationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ChaufferReservation> DbSet
        {
            get
            {
                return db.ChaufferReservations;
            }
        }
        #endregion
    }
}
