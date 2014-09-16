using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Status Repository
    /// </summary>
    public sealed class VehicleStatusRepository : BaseRepository<VehicleStatus>, IVehicleStatusRepository 
    {
        #region Constructor
        /// <summary>
        /// Vehicle Status Repository Constructor
        /// </summary>
        public VehicleStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleStatus> DbSet
        {
            get
            {
                return db.VehicleStatuses;
            }
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get All Vehicle Status for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleStatus> GetAll()
        {
            return DbSet.Where(vs => vs.UserDomainKey == UserDomainKey).ToList();
        }


        #endregion
    }
}
