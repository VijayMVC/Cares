using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Workplace Base API Controller
    /// </summary>
    public class WorkplaceBaseController : ApiController
    {
        #region Private
        private readonly IWorkplaceService workplaceSerive;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkplaceBaseController(IWorkplaceService workplaceSerive)
        {
            if (workplaceSerive == null)
            {
                throw new ArgumentNullException("workplaceSerive");
            }
            this.workplaceSerive = workplaceSerive;
        }

        #endregion
        #region Public
        /// <summary>
        /// Get Workplace Base data
        /// </summary>
        public WorkplaceBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return workplaceSerive.LoadWorkplaceBaseData().CreateFrom();
        }
        #endregion
    }
}