using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Image Repository
    /// </summary>
    public class VehicleImageRepository : BaseRepository<VehicleImage>, IVehicleImageRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleImageRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleImage> DbSet
        {
            get
            {
                return db.VehicleImages;
            }
        }
    }
}
