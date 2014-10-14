using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Vehicle Insurance Info Repository
    /// </summary>
    public interface IVehicleInsuranceInfoRepository : IBaseRepository<VehicleInsuranceInfo, long>
    {
        /// <summary>
        /// Association check of InsuranceType and vehicle Insurance Info
        /// </summary>
        bool IsInsuranceTypeAssociatedWithVehicleInsuranceInfo(long insuranceTypeId);
    }
}
