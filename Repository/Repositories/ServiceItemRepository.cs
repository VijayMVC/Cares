using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Microsoft.Practices.Unity;
using Cares.Repository.BaseRepository;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Service Item Repository
    /// </summary>
    public class ServiceItemRepository : BaseRepository<ServiceItem>, IServiceItemRepository
    {
        #region privte
        /// <summary>
        /// Service Item Orderby clause
        /// </summary>
        private readonly Dictionary<ServiceItemByColumn, Func<ServiceItem, object>> serviceItemOrderByClause = new Dictionary<ServiceItemByColumn, Func<ServiceItem, object>>
                    {
                        {ServiceItemByColumn.ServiceType, d =>d.ServiceType.ServiceTypeId},
                        {ServiceItemByColumn.Code, c => c.ServiceItemCode},
                        {ServiceItemByColumn.Name, d => d.ServiceItemName}
                    };
        #endregion
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

        /// <summary>
        /// Search Service Items
        /// </summary>
        public IEnumerable<ServiceItem> SearchServiceItems(ServiceItemSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<ServiceItem, bool>> query =
                serviceItem =>
                    (string.IsNullOrEmpty(request.ServiceItemFilterText) || (serviceItem.ServiceItemCode.Contains(request.ServiceItemFilterText)) ||
                     (serviceItem.ServiceItemName.Contains(request.ServiceItemFilterText))) && (
                         (!request.ServiceTypeId.HasValue || request.ServiceTypeId == serviceItem.ServiceTypeId)) && (serviceItem.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(serviceItemOrderByClause[request.ServiceItemOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(serviceItemOrderByClause[request.ServiceItemOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Self-code duplication validation
        /// </summary>
        public bool CodeDuplicationCheck(ServiceItem serviceItem)
        {
            return
                DbSet.Count(
                    dBserviceItem =>
                        dBserviceItem.ServiceItemId != serviceItem.ServiceItemId &&
                        dBserviceItem.ServiceItemCode == serviceItem.ServiceItemCode) > 0;
        }

        /// <summary>
        /// Get the detail object of service item
        /// </summary>
        public ServiceItem LoadServiceItemWithDetail(long serviceItemId)
        {
            return DbSet.Include(serviceItem => serviceItem.ServiceType)
                .FirstOrDefault(serviceItem => serviceItem.ServiceItemId == serviceItemId);
        }

        #endregion
    }
}
