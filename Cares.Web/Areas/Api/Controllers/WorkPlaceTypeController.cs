using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using WorkPlaceTypeSearchRequestResponse = Cares.Models.ResponseModels.WorkPlaceTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Workplace Type Controller
    /// </summary>
    [Authorize]
    public class WorkPlaceTypeController : ApiController
    {
        #region Private
        /// <summary>
        /// WorkplaceType Service 
        /// </summary>
        private readonly IWorkplaceTypeService workplaceTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPlaceTypeController(IWorkplaceTypeService workplaceTypeService)
        {
            this.workplaceTypeService = workplaceTypeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Workplace Type
        /// </summary>
        public Models.WorkPlaceTypeSearchRequestResponse Get([FromUri] WorkplaceTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
             WorkPlaceTypeSearchRequestResponse data=    workplaceTypeService.SearchWorkplaceType(request);
            return data.CreateFrom();
        }


        /// <summary>
        /// Delete  Workplace Type
        /// </summary>
        [ApiException]
        public Boolean Delete(Models.WorkPlaceType workplaceType)
        {
            if (workplaceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            workplaceTypeService.DeleteWorkPlaceType(workplaceType.WorkPlaceTypeId);
            return true;
        }


        /// <summary>
        /// Add/ Update WorkplaceType
        /// </summary>
        [ApiException]
        public Models.WorkPlaceType Post(Models.WorkPlaceType workplaceType)
        {
            if (workplaceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return workplaceTypeService.AddUpdateWorkPlaceType(workplaceType.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}