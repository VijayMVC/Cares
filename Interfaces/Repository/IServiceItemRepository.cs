using Cares.Models.DomainModels;

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
    }
}
