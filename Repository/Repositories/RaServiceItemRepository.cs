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
    public class RaServiceItemRepository : BaseRepository<RaServiceItem>, IRaServiceItemRepository
    {
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RaServiceItemRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<RaServiceItem> DbSet
        {
            get
            {
                return db.RaServiceItems;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Association check with service item before deletion of service item
        /// </summary>
        public bool IsServiceItemAssociatedWithRaServiceItem(long serviceItemId)
        {
            return DbSet.Count(rAServiceItem => rAServiceItem.ServiceItemId == serviceItemId && rAServiceItem.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion
    }
}
