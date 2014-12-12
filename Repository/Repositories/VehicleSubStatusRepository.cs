using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Sub Status Repository
    /// </summary>
    public class VehicleSubStatusRepository : BaseRepository<VehicleSubStatus>, IVehicleSubStatusRepository
    {
        #region Constructor
        /// <summary>
        /// Vehicle Sub Status Repository Constructor
        /// </summary>
        public VehicleSubStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleSubStatus> DbSet
        {
            get
            {
                return db.VehicleSubStatuses;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Association check b/n Vehicle Status and Vehicle Sub Status
        /// </summary>
        public bool IsVehicleSubStatusAssociatedWithVehicleStatus(long vehicleStatusId)
        {
            return DbSet.Count(vehiclesubstatus => vehiclesubstatus.VehicleStatusId == vehicleStatusId && vehiclesubstatus.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion
    }
}
