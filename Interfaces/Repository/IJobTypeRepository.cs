using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Job Type Repository Interface
    /// </summary>
    public interface IJobTypeRepository : IBaseRepository<JobType, long>
    {
        /// <summary>
        /// Search Job Type
        /// </summary>
        IEnumerable<JobType> SearchJobType(JobTypeSearchRequest request, out int rowCount);
        
        /// <summary>
        /// Code Duplication Check
        /// </summary>
        bool DoesJobTypeCodeExists(JobType jobType);
    }
}
