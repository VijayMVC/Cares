using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Vehicle Make Service Interface
    /// </summary>
    public interface IVehicleMakeService
    {
        /// <summary>
        /// Load all Vehicle Makes
        /// </summary>
        IEnumerable<VehicleMake> LoadAll();

        /// <summary>
        /// Delete Vehicle Make
        /// </summary>
        void DeleteVehicleMake(long vehicleMakeId);


        /// <summary>
        /// Search Vehicle Make
        /// </summary>
        VehicleMakeSearchRequestResponse SearchVehicleMake(VehicleMakeSearchRequest request);

        /// <summary>
        /// Add / Update Vehicle Make
        /// </summary>
        VehicleMake AddUpdateVehicleMake(VehicleMake vehicleMake);
    }
}
