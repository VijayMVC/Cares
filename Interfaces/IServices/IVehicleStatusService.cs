using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Vehicle Status Service Interface
    /// </summary>
    public interface IVehicleStatusService
    {
        /// <summary>
        /// Get All Vehicle Statuses
        /// </summary>
        IEnumerable<VehicleStatus> LoadAll();


        /// <summary>
        /// Search Vehicle Status
        /// </summary>
        VehicleStatusSearchRequestResponse SearchVehicleStatus(VehicleStatusSearchRequest request);

        /// <summary>
        /// Delete Vehicle Status
        /// </summary>
        void DeleteVehicleStatus(long vehicleStatusId);

        /// <summary>
        /// Save or Update Vehicle Status
        /// </summary>
        VehicleStatus SaveUpdateVehicleStatus(VehicleStatus vehicleStatus);
    }
}
