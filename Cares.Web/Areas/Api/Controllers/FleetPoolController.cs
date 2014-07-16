using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using Domain = Models.RequestModels;

namespace Cares.Web.Areas.Api.Controllers
{
    public class FleetPoolController : ApiController
    {
        #region Public
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