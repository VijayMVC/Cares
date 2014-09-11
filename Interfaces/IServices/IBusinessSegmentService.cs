
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Business Segment Service Interface
    /// </summary>
    public interface IBusinessSegmentService
    {
        /// <summary>
        /// Search BusinessSegment
        /// </summary>
        BusinessSegmentSearchRequestResponse SearchBusinessSegment(BusinessSegmentSearchRequest request);
    }
}
