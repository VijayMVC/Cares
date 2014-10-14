using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Vehicle Make API Controller
    /// </summary>
    public class VehicleMakeController : ApiController
    {  
        #region Private
        /// <summary>
        /// Document Service 
        /// </summary>
        private readonly IVehicleMakeService vehicleMakeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            this.vehicleMakeService = vehicleMakeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get vehicle Makes
        /// </summary>
        public VehicleMakeSearchRequestResponse Get([FromUri] VehicleMakeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  vehicleMakeService.SearchVehicleMake(request).CreateFromm();
        }

        /// <summary>
        /// Delete vehicle Make
        /// </summary>
        [ApiException]
        public bool Delete(VehicleMake vehicleMake)
        {
            if (vehicleMake == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleMakeService.DeleteVehicleMake(vehicleMake.VehicleMakeId);
            return true;
        }

        /// <summary>
        /// Add/ Update vehicle Make
        /// </summary>
        [ApiException]
        public VehicleMake Post(VehicleMake vehicleMake)
        {
            if (vehicleMake == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleMakeService.AddUpdateVehicleMake(vehicleMake.CreateFrom()).CreateFromm();
        }
        #endregion
    }
} 