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
    /// Vehicle Base Api Controller
    /// </summary>
    public class VehicleBaseController : ApiController
    {
        #region Private

        private readonly IVehicleService vehicleService;

        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleBaseController(IVehicleService vehicleService)
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
        /// Get  Vehicle base data
        /// </summary>
        public VehicleBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleService.GetBaseData().CreateFrom();
        }
        #endregion

    }
}