using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Workplace Repository Interface
    /// </summary>
    public interface IWorkplaceRepository : IBaseRepository<WorkPlace, long>
    {
        /// <summary>
        /// Search Workplace
        /// </summary>
        IEnumerable<WorkPlace> SearchWorkplace(WorkplaceSearchRequest request, out int rowCount);

        /// <summary>
        /// Get Workplace With Details 
        /// </summary>
        WorkPlace GetWorkplaceWithDetails(long workplaceId);

        /// <summary>
        /// Check if workplace is parrent of some other workplace
        /// </summary>
        bool IsWorkPalceParrent(long workplaceId);

        /// <summary>
        /// To check the availbility of workplace code
        /// </summary>
        bool DoesWorkPlaceCodeExists(WorkPlace workplace);
    }
}
   