using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
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
        /// Get fleet HireGroup Detail Report
        /// </summary>        
        IList<RptFleetHireGroupDetail>  GetFleetReport();

        /// <summary>
        /// Get Vechile against HireGroup
        /// </summary>
        GetVehicleResponse GetByHireGroup(VehicleSearchRequest request);

        /// <summary>
        /// Get Upgraded Vehicles
        /// </summary>
        GetVehicleResponse GetUpgradedVehiclesByHireGroup(VehicleSearchRequest request);

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
       
        /// <summary>
        /// Association check b/n vehicle and vehicle make
        /// </summary>
        bool IsVehicleMakeAssociatedWithVehicle(long vehicleMakeId);

        /// <summary>
        /// Association check b/n vehicle and vehicle Category
        /// </summary>
        bool IsVehicleCategoryAssociatedWithVehicle(long vehicleCategoryId);

        /// <summary>
        /// Association check b/n vehicle and vehicle Status
        /// </summary>
        bool IsVehicleStatusAssociatedWithVehicle(long vehicleStatusId);

        /// <summary>
        /// Association check b/n vehicle and vehicle Model
        /// </summary>
        bool IsVehicleModelAssociatedWithVehicle(long vehicleModelId);

        /// <summary>
        /// GetAvailable Vehicles for WebApi
        /// </summary>
        IEnumerable<WebApiAvailaleHireGroup> GetAvaibaleVehiclesForWebApi(IEnumerable<long> hireGroupDetailsIds, long domainKey);
    }
}






