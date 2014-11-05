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
    /// Hire Group Vehicles Api Controller
    /// </summary>
    [Authorize]
    public class HireGroupVehiclesController : ApiController
    {
        #region Private

        private readonly IVehicleService vehicleService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupVehiclesController(IVehicleService vehicleService)
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
        /// Get Vehicles
        /// </summary>
        public HireGroupVehiclesResponse Post(VehicleSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return vehicleService.GetByHireGroup(request).CreateFromFoRa();
        }
        #endregion
    }
}