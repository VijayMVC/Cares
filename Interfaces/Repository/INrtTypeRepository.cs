using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;
namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Nrt Type Repository Interface
    /// </summary>
    public interface INrtTypeRepository : IBaseRepository<NrtType, long>
    {
        /// <summary>
        /// Search NrtType
        /// </summary>
        IEnumerable<NrtType> SearchNrtType(NrtTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// Get NrtType with Details
        /// </summary>
        NrtType GetNrtTypeWithDetails(long nrtTypeId);

        /// <summary>
        /// NrtType Code validation check
        /// </summary>
        bool IsNrtTypeCodeExists(NrtType nrtType);

        /// <summary>
        /// Association check b/n Vehicle Status and Nrt Type
        /// </summary>
        bool IsVehicleStatusAssociatedWithNrtType(long vehicleStatusId);
    }
}
