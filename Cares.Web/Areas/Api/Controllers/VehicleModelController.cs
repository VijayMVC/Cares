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
    /// Vehicle Model API Controller
    /// </summary>
    public class VehicleModelController : ApiController
    {  
        #region Private
        /// <summary>
        /// Vehicle Model Service 
        /// </summary>
        private readonly IVehicleModelService vehicleModelService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            this.vehicleModelService = vehicleModelService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Vehicle Models
        /// </summary>
        public VehicleModelSearcgRequestResponse Get([FromUri] VehicleModelSearcgRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  vehicleModelService.SearchVehicleModel(request).CreateFromm();
        }

        /// <summary>
        /// Delete Vehicle Model
        /// </summary>
        [ApiException]
        public Boolean Delete(VehicleModel vehicleModel)
        {
            if (vehicleModel == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleModelService.DeleteVehicleModel(vehicleModel.VehicleModelId);
            return true;
        }

        /// <summary>
        /// Add/ Update Vehicle Model
        /// </summary>
        [ApiException]
        public VehicleModel Post(VehicleModel vehicleModel)
        {
            if (vehicleModel == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleModelService.AddUpdateVehicleModel(vehicleModel.CreateFromm()).CreateFromm();
        }
        #endregion
    }
} 