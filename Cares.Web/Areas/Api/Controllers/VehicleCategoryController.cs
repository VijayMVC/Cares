using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using VehicleCategorySearchRequestResponse = Cares.Web.Models.VehicleCategorySearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    ///   Vehicle Category Controller
    /// </summary>
    public class VehicleCategoryController : ApiController
    {
       #region Private
       private readonly IVehicleCategoryService vehicleCategoryService;
       #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
       public VehicleCategoryController(IVehicleCategoryService vehicleCategoryService)
        {
            if (vehicleCategoryService == null)
            {
                throw new ArgumentNullException("vehicleCategoryService");
            }
            this.vehicleCategoryService = vehicleCategoryService;
        }

        #endregion
       #region Public

        /// <summary>
       /// Get vehicle Categories
        /// </summary>
       public VehicleCategorySearchRequestResponse Get([FromUri] VehicleCategorySearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleCategoryService.SearchVehicleCategory(request).CreateFrom();
        }

        /// <summary>
       /// Delete Vehicle Category
       /// </summary>
        [ApiException]
       public Boolean Delete(VehicleCategory vehicleCategory)
        {
            if (vehicleCategory == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleCategoryService.DeleteVehicleCategory(vehicleCategory.VehicleCategoryId);
            return true;
        }

        /// <summary>
        ///  ADD / Update Vehicle Category
        /// </summary>
        [ApiException]
        public VehicleCategory Post(VehicleCategory vehicleCategory)
        {
            if (vehicleCategory == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleCategoryService.SaveVehicleCategory(vehicleCategory.CreateFromm()).CreateFromm();
        }

        #endregion
    }
}