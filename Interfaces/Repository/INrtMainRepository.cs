
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// NRT Main Repository interface
    /// </summary>
    public interface INrtMainRepository: IBaseRepository<NrtMain, long>
    {
        /// <summary>
        /// Associaton check with nrt type before deletion
        /// </summary>
        bool IsNrtMainAssociatedWithNrtType(long nrtTypeId);

        /// <summary>
        /// Get all NRT Main
        /// </summary>
        NrtQueueSearchResponse GetNrtMainsForNrtQueue(NrtQueueSearchRequest request);

    }
}
