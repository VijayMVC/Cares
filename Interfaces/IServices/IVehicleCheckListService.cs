using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Company Service Interface
    /// </summary>
    public interface IVehicleCheckListService
    {
        /// <summary>
        /// Load all Vehicle CheckLists
        /// </summary>
        IEnumerable<VehicleCheckList> LoadAll();

        /// <summary>
        /// Delete Vehicle CheckList
        /// </summary>
        void DeleteVehicleCheckList(long vehicleCheckListId);
       
        /// <summary>
        /// Search Vehicle CheckList
        /// </summary>
        VehicleCheckListSearchRequestResponse SearchVehicleCheckList(VehicleCheckListSearchRequest request);

        /// <summary>
        /// Add / Update Vehicle CheckList
        /// </summary>
        VehicleCheckList AddUpdateVehicleCheckList(VehicleCheckList vehicleCheckList);

        /// <summary>
        /// Load all Vehicle CheckLists For Vehicle
        /// </summary>
        IEnumerable<VehicleCheckList> GetForVehicle(long vehicleId);
    }
}
