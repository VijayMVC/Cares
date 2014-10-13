using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// IVehicle Model Service Interface
    /// </summary>
    public interface IVehicleModelService
    {
        /// <summary>
        /// Load all Vehicle Models
        /// </summary>
        IEnumerable<VehicleModel> LoadAll();

        /// <summary>
        /// Delete Vehicle Model
        /// </summary>
        void DeleteVehicleModel(long vehicleModelId);


        /// <summary>
        /// Search Vehicle Model
        /// </summary>
        VehicleModelSearcgRequestResponse SearchVehicleModel(VehicleModelSearcgRequest request);

        /// <summary>
        /// Add / Update Vehicle Model
        /// </summary>
        VehicleModel AddUpdateVehicleModel(VehicleModel vehicleModel);
    }
}
