using System.Data.Entity;
using System.Linq;
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
        #region Public

        /// <summary>
        /// Association check of InsuranceType and vehicle Insurance Info
        /// </summary>
        public bool IsInsuranceTypeAssociatedWithVehicleInsuranceInfo(long insuranceTypeId)
        {
            return DbSet.Count(vehicleInsuranceInfo => vehicleInsuranceInfo.InsuranceTypeId == insuranceTypeId
                && vehicleInsuranceInfo.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion
    }
}
