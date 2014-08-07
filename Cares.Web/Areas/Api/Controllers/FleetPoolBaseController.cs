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
    /// Fleet Pool Base Controller
    /// </summary>
    public class FleetPoolBaseController: ApiController
    {
        #region Public

        /// <summary>
        /// Get Fleet Pool Base Data 
        /// </summary>
        public FleetPoolBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            FleetPoolBaseDataResponse abc = fleetPoolService.LoadFleetPoolBaseData().CreateFrom();
            return abc;
        }
        #endregion

        #region Private
        private readonly IFleetPoolService fleetPoolService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FleetPoolBaseController(IFleetPoolService fleetPoolService)
        {
            if (fleetPoolService == null)
            {
                throw new ArgumentNullException("fleetPoolService");
            }
            this.fleetPoolService = fleetPoolService;
        }

        #endregion
    }
}