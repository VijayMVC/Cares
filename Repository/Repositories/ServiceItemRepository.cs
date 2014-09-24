using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Service Item Repository
    /// </summary>
    public class ServiceItemRepository : BaseRepository<ServiceItem>, IServiceItemRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceItemRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ServiceItem> DbSet
        {
            get
            {
                return db.ServiceItems;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Service item for User Domain Key
        /// </summary>
        public override IEnumerable<ServiceItem> GetAll()
        {
            return DbSet.Where(seviceItem => seviceItem.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Association check with service type before deletion of service type
        /// </summary>
        public bool IsServiceItemAssociatedWithServiceType(long serviceTypeId)
        {
           return DbSet.Count(serviceItem => serviceItem.ServiceTypeId == serviceTypeId) > 0;
        }

        #endregion
    }
}
