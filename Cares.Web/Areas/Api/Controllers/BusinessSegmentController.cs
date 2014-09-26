using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Segment Controller
    /// </summary>
    public class BusinessSegmentController : ApiController
    {
        #region Private
        /// <summary>
        /// Business Segment Service 
        /// </summary>
        private readonly IBusinessSegmentService businessSegmentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Business Segment Constructor
        /// </summary>
        public BusinessSegmentController(IBusinessSegmentService businessSegmentService)
        {
            this.businessSegmentService = businessSegmentService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Business Segments from database
        /// </summary>
        public BusinessSegmentSearchRequestResponse Get([FromUri] BusinessSegmentSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessSegmentService.SearchBusinessSegment(request).CreateFrom();
        }


        /// <summary>
        /// Delete Business Segment
        /// </summary>
         [ApiException]
        public bool Delete(BusinessSegment businessSegment)
        {
            if (businessSegment == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            businessSegmentService.DeleteBusinessSegment(businessSegment.BusinessSegmentId);
            return true;
        }

        /// <summary>
        /// Add/ Update Business Segment
        /// </summary>
        [ApiException]
        public BusinessSegment Post(BusinessSegment businessSegment)
        {
            if (businessSegment == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessSegmentService.AddUpdateBusinessSegment(businessSegment.CreateFrom()).CreateFromm();
        }
        #endregion
    }
}