using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Fleet Pool Api Controller
    /// </summary>
    public class FleetPoolController : ApiController
    {
        #region Public
        /// <summary>
        /// Dalete Fleet Pool
        /// </summary>
        public void Delete(FleetPool fleetPool)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
           fleetPoolService.DeleteFleetPool(Convert.ToInt32( fleetPool.FleetPoolId));
        }
        /// <summary>
        /// Get FleetPools
        /// </summary>
        public FleetPoolResponse Get([FromUri] FleetPoolSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return fleetPoolService.SerchFleetPool(request).CreateFrom();
        }        
        /// <summary>
        /// update FleetPools
        /// </summary>
        public FleetPool Post(FleetPool fleetPool)
        {
            if (fleetPool == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return fleetPoolService.SaveFleetPool(fleetPool.CreateFrom()).CreateFrom();
        }
       
        #endregion
        #region Constructor

        public FleetPoolController(IFleetPoolService ifleetPoolService)
        {
            fleetPoolService = ifleetPoolService;
        }
        #endregion
        #region Private
        private readonly IFleetPoolService fleetPoolService;
        #endregion
    }
}