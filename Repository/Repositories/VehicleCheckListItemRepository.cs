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

        #endregion
    }
}
