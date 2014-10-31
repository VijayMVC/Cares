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
    /// Work Location Controller
    /// </summary>
    [Authorize]
    public class WorkLocationController : ApiController
    {
        #region Private
        /// <summary>
        /// Company Service 
        /// </summary>
        private readonly IWorkLocationService workLocationService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkLocationController(IWorkLocationService workLocationService)
        {
            this.workLocationService = workLocationService;
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Work Locations
        /// </summary>
        public WorkLocationSerachRequestResponse Get([FromUri] WorkLocationSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return workLocationService.SearchWorkLocation(request).CreateFrom();
        }

        /// <summary>
        /// Delete Work Location
        /// </summary>
        [ApiException]
        public Boolean Delete(WorkLocation workLocation)
        {
            if (workLocation == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            workLocationService.DeleteWorkLocation(workLocation.WorkLocationId);
            return true;
        }

        /// <summary>
        ///ADD/ Update Work Location
        /// </summary>
        [ApiException]
        public WorkLocation Post(WorkLocation workLocation)
        {
            if (workLocation == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return workLocationService.SaveWorkLocation(workLocation.CreateFrom()).CreateFromm();
        }
        #endregion
    }
}