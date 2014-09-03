using System.Data.Entity;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Disposal Info Repository
    /// </summary>
    public class VehicleDisposalInfoRepository : BaseRepository<VehicleDisposalInfo>, IVehicleDisposalInfoRepository
    {
         #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleDisposalInfoRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleDisposalInfo> DbSet
        {
            get
            {
                return db.VehicleDisposalInfos;
            }
        }
        #endregion

    }
}
