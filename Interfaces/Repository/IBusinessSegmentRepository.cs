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
        /// Search Business Segment
        /// </summary>
        IEnumerable<BusinessSegment> SearchBusinessSegment(BusinessSegmentSearchRequest businessSegmentSearchRequest,
            out int rowCount);


        /// <summary>
        /// Business Segment Code validation check
        /// </summary>
        bool IsBusinessSegmentCodeExists(BusinessSegment businessSegment);
    }
}

