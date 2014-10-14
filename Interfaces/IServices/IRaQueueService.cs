using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// RA Queue Service Interface
    /// </summary>
    public interface IRaQueueService
    {
        /// <summary>
        /// Get RA Queue Base Data
        /// </summary>
        /// <returns></returns>
        RaQueueBaseResponse GetBaseData();

        /// <summary>
        /// Load RA Queue, based on search filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        RaMainForRaQueueSearchResponse LoadRaQueues(RaQueueSearchRequest request);
    }
}
