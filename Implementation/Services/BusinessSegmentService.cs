using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Segment Service
    /// </summary>
    public  class BusinessSegmentService : IBusinessSegmentService
    {
        #region Private
        private readonly IBusinessSegmentRepository businessSegmentRepository;

        #endregion
        #region Constructor
        public BusinessSegmentService(IBusinessSegmentRepository businessSegmentRepository)
        {
            this.businessSegmentRepository = businessSegmentRepository;
        }

        #endregion
        #region Public
        /// <summary>
        /// Search BusinessSegment
        /// </summary>
        public BusinessSegmentSearchRequestResponse SearchBusinessSegment(BusinessSegmentSearchRequest request)
        {
            int rowCount;
            return new BusinessSegmentSearchRequestResponse
            {
                BusinessSegments = businessSegmentRepository.SearchBusinessSegment(request, out rowCount),
                TotalCount = rowCount
            };
        }
        #endregion
    }
}
