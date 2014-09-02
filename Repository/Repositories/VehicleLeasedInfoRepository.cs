using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Leased Info Repository
    /// </summary>
    public class VehicleLeasedInfoRepository : BaseRepository<VehicleLeasedInfo>, IVehicleLeasedInfoRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleLeasedInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleLeasedInfo> DbSet
        {
            get
            {
                return db.VehicleLeasedInfos;
            }
        }
        #endregion
    }
}
