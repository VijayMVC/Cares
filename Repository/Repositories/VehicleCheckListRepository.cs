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
    /// Vehicle Check List Repository
    /// </summary>
    public sealed class VehicleCheckListRepository : BaseRepository<VehicleCheckList>, IVehicleCheckListRepository
    {
        #region Constructor
        /// <summary>
        /// Vehicle Check List Repository Constructor
        /// </summary>
        public VehicleCheckListRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleCheckList> DbSet
        {
            get
            {
                return db.VehicleCheckLists;
            }
        }

        #endregion

        #region Public

        /// <summary>
        /// Get All Vehicle Check List for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleCheckList> GetAll()
        {
            return DbSet.Where(vcl => vcl.UserDomainKey == UserDomainKey).ToList();
        }

        #endregion
    }
}
