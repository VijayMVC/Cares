using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehcilce Image Detail Repository
    /// </summary>
    public class VehcilceImageDetailRepository : BaseRepository<VehicleImageDetail>, IVehcilceImageDetailRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehcilceImageDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleImageDetail> DbSet
        {
            get
            {
                return db.VehcilceImageDetails;
            }
        }

        #endregion
    }
}
