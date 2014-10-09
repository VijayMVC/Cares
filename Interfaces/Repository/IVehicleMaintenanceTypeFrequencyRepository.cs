using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Maintenance Type Frequency Repository Interface
    /// </summary>
    public interface IVehicleMaintenanceTypeFrequencyRepository : IBaseRepository<VehicleMaintenanceTypeFrequency, long>
    {
        /// <summary>
        /// Association check b/w vehicle Maintenance Type Frequency and Maintenance Type
        /// </summary>
        bool IsVehicleMaintenanceTypeFrequencyAssociatedMaintenanceType(long maintenanceTypeId);
    }
}
