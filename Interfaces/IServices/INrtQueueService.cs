using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// NRT Queue Service Interface
    /// </summary>
    public interface INrtQueueService
    {

        /// <summary>
        /// Get NRT Queue Base Data
        /// </summary>
        /// <returns></returns>
        NrtQueueBaseResponse GetBaseData();

        /// <summary>
        /// Load NRT Queue, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        NrtQueueSearchResponse LoadNrtQueues(NrtQueueSearchRequest request);
    }
}
