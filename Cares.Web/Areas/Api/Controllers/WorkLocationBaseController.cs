using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Work Location Base Controller
    /// </summary>
    public class WorkLocationBaseController :ApiController
    {
       #region Private
        private readonly IWorkLocationService workLocationService;

        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkLocationBaseController(IWorkLocationService workLocationService)
        {
            if ( workLocationService == null)
            {
                throw new ArgumentNullException("workLocationService");
            }
            this.workLocationService = workLocationService;
        }

        #endregion
       #region Public
        /// <summary>
        /// Get Worklocation Base data
        /// </summary>
        public WorkLocationBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return workLocationService.LoadWorkLocationBaseData().CreateFrom();
        }
        #endregion
    }
}