using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Segment Controller
    /// </summary>
    public class BusinessSegmentController : ApiController
    {
        #region Private
        /// <summary>
        /// BusinessSegment Service 
        /// </summary>
        private readonly IBusinessSegmentService businessSegmentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessSegmentController(IBusinessSegmentService businessSegmentService)
        {
            this.businessSegmentService = businessSegmentService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get BusinessSegment
        /// </summary>
        public Models.BusinessSegmentSearchRequestResponse Get([FromUri] BusinessSegmentSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessSegmentService.SearchBusinessSegment(request).CreateFrom();
        }
        #endregion
    }
}