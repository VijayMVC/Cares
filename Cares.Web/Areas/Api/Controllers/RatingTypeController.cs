using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using RatingTypeSearchRequestResponse = Cares.Web.Models.RatingTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rating Type Controller
    /// </summary>
    [Authorize]
    public class RatingTypeController : ApiController
    {
       #region Private
        private readonly IRatingTypeService ratingTypeService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RatingTypeController(IRatingTypeService ratingTypeService)
        {
            if (ratingTypeService == null)
            {
                throw new ArgumentNullException("ratingTypeService");
            }
            this.ratingTypeService = ratingTypeService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Rating Types
        /// </summary>
        public RatingTypeSearchRequestResponse Get([FromUri] RatingTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return ratingTypeService.SearchRatingType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Rating Type 
        /// </summary>
        [ApiException]
        public Boolean Delete(BpRatingType bpRatingType)
        {
            if (bpRatingType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            ratingTypeService.DeleteRatingType(bpRatingType.BpRatingTypeId);
            return true;
        }

        /// <summary>
        /// ADD/ Update Rating Type
        /// </summary>
        [ApiException]
        public BpRatingType Post(BpRatingType area)
        {
            if (area == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return ratingTypeService.SaveRatingType(area.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}