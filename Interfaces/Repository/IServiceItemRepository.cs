using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Service Item Repository Interface
    /// </summary>
    public interface IServiceItemRepository : IBaseRepository<ServiceItem, long>
    {
        /// <summary>
        /// Association check with service type before deletion of service type
        /// </summary>
        bool IsServiceItemAssociatedWithServiceType(long serviceTypeId);

        /// <summary>
        /// Search Service Items
        /// </summary>
        IEnumerable<ServiceItem> SearchServiceItems(ServiceItemSearchRequest request, out int rowCount);

        /// <summary>
        /// Self-code duplication validation
        /// </summary>
        bool CodeDuplicationCheck(ServiceItem serviceItem);

        /// <summary>
        /// Get the detail object of service item
        /// </summary>
        ServiceItem LoadServiceItemWithDetail(long serviceItemId);

    }
}
