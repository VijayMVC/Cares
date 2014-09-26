using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// RA Service Item Repository InterFace
    /// </summary>
    public interface IRaServiceItemRepository : IBaseRepository<RaServiceItem, long>
    {
        /// <summary>
        /// Association check with service item before deletion of service item
        /// </summary>
        bool IsServiceItemAssociatedWithRaServiceItem(long serviceItemId);
    }
}
