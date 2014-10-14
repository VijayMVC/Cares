using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Vehicle Status Controller 
    /// </summary>
    public class VehicleStatusController : ApiController
    {
        #region Private
        /// <summary>
        /// Private 
        /// </summary>
        private readonly IVehicleStatusService vehicleStatusService;
        #endregion
        #region Constructor
        /// <summary>
        /// Vehicle Status Constructor
        /// </summary>>
        public VehicleStatusController(IVehicleStatusService vehicleStatusService)
        {
            this.vehicleStatusService = vehicleStatusService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Vehicle Statuses
        /// </summary>
        public VehicleStatusSearchRequestResponse Get([FromUri] VehicleStatusSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleStatusService.SearchVehicleStatus(oppRequest).CreateFrom();
        }

        /// <summary>
        /// Delete Vehicle Status
        /// </summary>
        [ApiException]
        public Boolean Delete(VehicleStatus vehicleStatus)
        {
            if (Request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleStatusService.DeleteVehicleStatus(vehicleStatus.VehicleStatusId);
            return true;
        }

        /// <summary>
        /// Add/Update Vehicle Status
        /// </summary>
        [ApiException]
        public VehicleStatus Post(VehicleStatus vehicleStatus)
        {
            if (vehicleStatus == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleStatusService.SaveUpdateVehicleStatus(vehicleStatus.CreateFrom()).CreateFrom();
        }   
        #endregion   
    }
}