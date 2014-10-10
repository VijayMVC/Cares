using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;


namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Category Interface
    /// </summary>
    public interface IVehicleCategoryRepository : IBaseRepository<VehicleCategory, long>
    {
        /// <summary>
        /// Search Vehicle Category
        /// </summary>
        IEnumerable<VehicleCategory> SearchVehicleCategory(VehicleCategorySearchRequest request, out int rowCount);

        /// <summary>
        /// Vehicle Category Self code duplication check
        /// </summary>
        bool VehicleCategoryCodeDuplicationCheck(VehicleCategory vehicleCategory);
    }
}
