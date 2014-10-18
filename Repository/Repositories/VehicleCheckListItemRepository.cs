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
    /// Vehicle Check List Item Repository
    /// </summary>
    public class VehicleCheckListItemRepository : BaseRepository<VehicleCheckListItem>, IVehicleCheckListItemRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleCheckListItemRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleCheckListItem> DbSet
        {
            get
            {
                return db.VehicleCheckListItems;
            }
        }
        #endregion

        #region Public
        /// <summary>
        /// Get All Vehicle Check List Items for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleCheckListItem> GetAll()
        {
            return DbSet.Where(vCheckListItem => vCheckListItem.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Association check Vehicle CheckList Item with  Vehicle CheckList
        /// </summary>
        public bool IsVehicleCheckListItemAssociatedWithVehicleCheckList(long vehicleCheckListId)
        {
            return DbSet.Count(raVehicleCheckListItem => raVehicleCheckListItem.VehicleCheckListId == vehicleCheckListId) > 0;
        }

        /// <summary>
        /// Get For Vehicle
        /// </summary>
        public IEnumerable<VehicleCheckList> GetByVehicleId(long vehicleId)
        {
            return DbSet.Where(vch => vch.UserDomainKey == UserDomainKey && vch.VehicleId == vehicleId && vch.VehicleCheckListId.HasValue)
                .Select(vch => vch.VehicleCheckList).Distinct().ToList();
        }

        #endregion
    }
}
