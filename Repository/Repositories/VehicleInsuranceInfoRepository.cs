using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Insurance Info Repository 
    /// </summary>
    public class VehicleInsuranceInfoRepository : BaseRepository<VehicleInsuranceInfo>, IVehicleInsuranceInfoRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleInsuranceInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleInsuranceInfo> DbSet
        {
            get
            {
                return db.VehicleInsuranceInfos;
            }
        }
        #endregion
    }
}
