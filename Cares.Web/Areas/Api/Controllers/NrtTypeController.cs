using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// INrt Type Controller 
    /// </summary>
    [Authorize]
    public class NrtTypeController : ApiController
    {
        #region Private
        /// <summary>
        /// Private 
        /// </summary>
        private readonly INrtTypeService nrtTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// INrt Type Constructor
        /// </summary>>
        public NrtTypeController(INrtTypeService nrtTypeService)
        {
            this.nrtTypeService = nrtTypeService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get Nrt Types
        /// </summary>
        public Models.NrtTypeSearchRequestResponse Get([FromUri] NrtTypeSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return nrtTypeService.SearchNrtType(oppRequest).CreateFrom();
        }

        /// <summary>
        /// Delete Nrt Type
        /// </summary>
        [ApiException]
        public Boolean Delete(Models.NrtType request)
        {
            if (Request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            nrtTypeService.DeleteNtrType(request.NrtTypeId);
            return true;
        }
        /// <summary>
        /// Add/Update Nrt Type
        /// </summary>
        [ApiException]
        public Models.NrtType Post(Models.NrtType request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return nrtTypeService.AddUpdateNtrType(request.CreateFrom()).CreateNrtTypeFrom();
        }   
        #endregion   
    }
}