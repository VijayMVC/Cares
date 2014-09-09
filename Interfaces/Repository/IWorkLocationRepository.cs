using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Work Location Repository Interface
    /// </summary>
    public interface IWorkLocationRepository : IBaseRepository<WorkLocation, long>
    {
        /// <summary>
        /// Search Work Location
        /// </summary>
        IEnumerable<WorkLocation> SearchWorkLocation(WorkLocationSearchRequest request, out int rowCount);

        /// <summary>
        /// Get Work Location With Details
        /// </summary>
        WorkLocation GetWorkLocationWithDetails(long workLocationId);
    }
}
