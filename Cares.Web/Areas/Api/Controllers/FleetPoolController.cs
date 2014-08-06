using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using Domain = Models.RequestModels;
using DomainModel = Models.DomainModels;

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
        public FleetPoolResponse Get([FromUri] Domain.FleetPoolSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return fleetPoolService.SerchFleetPool(request).CreateFrom();
        }
        /// <summary>
        /// Add new FleetPools
        /// </summary>
        public FleetPool Put(DomainModel.FleetPool fleetPool) 
        {
            if (fleetPool == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return  fleetPoolService.AddNewFleetPool(fleetPool).CreateFrom();
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