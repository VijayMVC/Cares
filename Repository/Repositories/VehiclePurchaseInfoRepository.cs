using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Purchase Info Repository
    /// </summary>
    public class VehiclePurchaseInfoRepository : BaseRepository<VehiclePurchaseInfo>, IVehiclePurchaseInfoRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehiclePurchaseInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehiclePurchaseInfo> DbSet
        {
            get
            {
                return db.VehiclePurchaseInfos;
            }
        }
        #endregion
    }
}
