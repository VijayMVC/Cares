using System;
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
        public GetVehicleResponse Get([FromUri] VehicleSearchRequest request)
        {
            return vehicleService.GetByHireGroup(request).CreateFrom();
        }
        #endregion
    }
}