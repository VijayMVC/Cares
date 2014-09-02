using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;
using DomainRequestModel = Cares.Models.RequestModels;
using Cares.Web.Models;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Vehicle Api Controller
    /// </summary>
    public class VehicleController : ApiController
    {
        #region Private
        private readonly IVehicleService vehicleService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleController(IVehicleService vehicleService)
        {
            if (vehicleService == null)
            {
                throw new ArgumentNullException("vehicleService");
            }

            this.vehicleService = vehicleService;


        }
        #endregion

        #region Public

        // GET api/<controller>
        public GetVehicleResponse Get([FromUri] DomainRequestModel.VehicleSearchRequest request)
        {
            if (request == null && !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleService.LoadVehicles((request)).CreateFrom();
        }

        /// <summary>
        /// Update/Update a Vehicle
        /// </summary>
        [ApiException]
        public VehicleListViewContent Post(VehicleDetail vehicleDetail)
        {
            if (vehicleDetail == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            VehicleListViewContent vehicle = vehicleService.SaveVehicle(vehicleDetail.CreateFrom()).CreateFromListViewContent();
            return vehicle;
        }

        /// <summary>
        /// Delete a Vehicle
        /// </summary>
        public void Delete(VehicleDetail vehicle)
        {
            if (vehicle == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleService.DeleteVehicle(vehicleService.FindById(vehicle.VehicleId));
        }
        #endregion

    }
}