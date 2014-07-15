using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Interfaces.IServices;

namespace Cares.Web.Areas.Api.Controllers
{
    public class FleetPoolController : ApiController
    {
        #region Public
        /// <summary>
        /// Get FleetPools
        /// </summary>
        public IQueryable<global::Models.DomainModels.FleetPool> Get([FromUri] global::Models.RequestModels.FleetPoolSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return fleetPoolService.LoadAll(request);
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