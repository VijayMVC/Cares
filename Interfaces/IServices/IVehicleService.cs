using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Vehicle Interface
    /// </summary>
    public interface IVehicleService
    {
        /// <summary>
        /// Get By Hire Group
        /// </summary>
        GetVehicleResponse GetByHireGroup(VehicleSearchRequest request);

        /// <summary>
        /// Get By Id
        /// </summary>
        Vehicle GetById(long vehicleId);

    }
}
