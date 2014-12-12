using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    public class RaVehicleCheckListRepository : BaseRepository<RaVehicleCheckList>, IRaVehicleCheckListRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RaVehicleCheckListRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaVehicleCheckList> DbSet
        {
            get
            {
                return db.RaVehicleCheckLists;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Association check Ra Vehicle Check List with  Vehicle CheckList
        /// </summary>
        public bool IsRaVehicleCheckListAssociatedWithVehicleCheckList(long vehicleCheckListId)
        {
            return DbSet.Count(raVehicleCheckList => raVehicleCheckList.VehicleCheckListId == vehicleCheckListId && raVehicleCheckList.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion

    }
}
