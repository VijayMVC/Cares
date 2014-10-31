using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Occupation Type API Controller
    /// </summary>
    [Authorize]
    public class OccupationTypeController : ApiController
    {  
        #region Private
        /// <summary>
        /// Occupation Service  Type
        /// </summary>
        private readonly IOccupationTypeService occupationTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OccupationTypeController(IOccupationTypeService occupationTypeService)
        {
            this.occupationTypeService = occupationTypeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Occupation Type
        /// </summary>
        public OccupationTypeSearchRequestResponse Get([FromUri] OccupationTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  occupationTypeService.SearchOccupationType(request).CreateFromm();
        }

        /// <summary>
        /// Delete Occupation Type
        /// </summary>
        [ApiException]
        public Boolean Delete(OccupationType request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            occupationTypeService.DeleteOccupationType(request.OccupationTypeId);
            return true;
        }

        /// <summary>
        /// Add/ Update Occupation Type
        /// </summary>
        [ApiException]
        public OccupationType Post(OccupationType request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return occupationTypeService.AddUpdateOccupationType(request.CreateFromm()).CreateFromm();
        }
        #endregion
    }
} 