using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Repository Interface
    /// </summary>
    public interface IVehicleRepository : IBaseRepository<Vehicle, long>
    {

        /// <summary>
        /// Get Vechile against HireGroup
        /// </summary>
        GetVehicleResponse GetByHireGroup(VehicleSearchRequest request);

        /// <summary>
        /// Get Vehicle List Based On Search Criteria
        /// </summary>
        GetVehicleResponse GetVehicles(VehicleSearchRequest request);

        /// <summary>
        /// Get Vehicle Info For NRT
        /// </summary>
        /// <param name="operationWorkPlaceId"></param>
        /// <param name="startDtTime"></param>
        /// <param name="endDtTime"></param>
        /// <returns></returns>
        IEnumerable<Vehicle> GetVehicleInfoForNrt(long operationWorkPlaceId, DateTime startDtTime,
            DateTime endDtTime);

        /// <summary>
        /// Load Dependencies
        /// </summary>
        void LoadDependencies(Vehicle vehicle);


        /// <summary>
        /// Check Vehicle Plate Number Already Exist
        /// </summary>
        bool DuplicateVehiclePlateNumber(string plateNumber, long vehicleId);
    }
}






