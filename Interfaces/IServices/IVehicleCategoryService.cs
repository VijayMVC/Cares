
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Vehicle Category Service Interface
    /// </summary>
    public interface IVehicleCategoryService
    {

        /// <summary>
        /// Search Vehicle Category
        /// </summary>
        VehicleCategorySearchRequestResponse SearchVehicleCategory(VehicleCategorySearchRequest request);

        /// <summary>
        /// Delete Vehicle Category by id
        /// </summary>
        void DeleteVehicleCategory(long vehicleCategoryId);

        /// <summary>
        /// Add /Update Vehicle Category
        /// </summary>
        VehicleCategory SaveVehicleCategory(VehicleCategory vehicleCategory);
    }
}
