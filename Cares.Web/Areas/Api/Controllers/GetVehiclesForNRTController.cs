using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Vehicles For NRT API Controller
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [Authorize]
    public class GetVehiclesForNRTController : ApiController
    {
        #region Private

        private readonly IVehicleService vehicleService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetVehiclesForNRTController(IVehicleService vehicleService)
        {
            if (vehicleService == null)
            {
                throw new ArgumentNullException("vehicleService");
            }
            this.vehicleService = vehicleService;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Hire Groups by Hire Group Code, Vehicle Make / Category / Model / Model Year
        /// </summary>
        public IEnumerable<Vehicle> Post(VehicleSeacrhRequestForNRT request)
        {
            if (request == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return vehicleService.GetVehicleInfoForNrt(request.OperationWorkPlaceId, request.StartDtTime, request.EndDtTime)
                .Select(hg => hg.CreateFromForNrt());
        }

        #endregion
    }
}