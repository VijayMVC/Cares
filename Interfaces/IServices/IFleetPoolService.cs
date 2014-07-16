using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// FleetPool Interface
    /// </summary>
    public interface IFleetPoolService
    {
        /// <summary>
        /// Load All FleetPools
        /// </summary>
        FleetPoolResponse SerchFleetPool(FleetPoolSearchRequest searchRequest);

        /// <summary>
        /// Load Fleet Pool Base Data
        /// </summary>
        FleetPoolBaseDataResponse LoadFleetPoolBaseData();

        /// <summary>
        /// Dalete Fleet Pool
        /// </summary>
        /// <param name="id"></param>
        void DeleteFleetPool(int id);
    }
}
