using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Workplace controller
    /// </summary>
    public class WorkplaceController : ApiController
    {
        #region Private
        private readonly IWorkplaceService workplaceService;
        #endregion
        #region Constructor
        /// <summary>
        /// Workplace Constructor
        /// </summary>
        public WorkplaceController(IWorkplaceService workplaceService)
        {
            this.workplaceService = workplaceService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get WorkPlace
        /// </summary>
        public WorkplaceSearchRequestResponse Get([FromUri] WorkplaceSearchRequest workplaceSearchRequest)
        {
            if (workplaceSearchRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  workplaceService.SearchWorkplace(workplaceSearchRequest).CreateFrom();
        }
        /// <summary>
        /// Delete WorkPlace 
        /// </summary>
        [ApiException]
        public Boolean Delete(Operation oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          //  operationService.DeleteOperation(oppRequest.CreateFrom());
            return true;
        }

        /// <summary>
        ///  ADD/ Update WorkPlace
        /// </summary>
        [ApiException]
        public WorkPlace Post(WorkPlace oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
           return workplaceService.SaveWorkPlace(oppRequest.CreateFrom()).CreateFrom();
        }
        #endregion
    }
}