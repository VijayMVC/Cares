using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Segment Repository Interface
    /// </summary>
    public interface IBusinessSegmentRepository : IBaseRepository<BusinessSegment, long>
    {

        /// <summary>
        /// Search BusinessSegment
        /// </summary>
        IEnumerable<BusinessSegment> SearchBusinessSegment(BusinessSegmentSearchRequest businessSegmentSearchRequest,
            out int rowCount);


        /// <summary>
        /// BusinessSegment Code validation check
        /// </summary>
        bool IsBusinessSegmentCodeExists(BusinessSegment businessSegment);
    }
}

