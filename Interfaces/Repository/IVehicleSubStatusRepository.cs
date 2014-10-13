using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Sub Status Repository Interface
    /// </summary>
    public interface IVehicleSubStatusRepository : IBaseRepository<VehicleSubStatus, long>
    {
        /// <summary>
        /// Association check b/n Vehicle Status and Vehicle Sub Status
        /// </summary>
        bool IsVehicleSubStatusAssociatedWithVehicleStatus(long vehicleStatusId);
    }
}
