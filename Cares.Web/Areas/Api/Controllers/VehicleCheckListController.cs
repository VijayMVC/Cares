using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Vehicle Check List Controller
    /// </summary>
    [Authorize]
    public class VehicleCheckListController : ApiController
    {
       #region Private
        private readonly IVehicleCheckListService vehicleCheckListService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleCheckListController(IVehicleCheckListService vehicleCheckListService)
        {
            if (vehicleCheckListService == null)
            {
                throw new ArgumentNullException("vehicleCheckListService");
            }
            this.vehicleCheckListService = vehicleCheckListService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Vehicle CheckLists
        /// </summary>
        public VehicleCheckListSearchRequestResponse Get([FromUri] VehicleCheckListSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleCheckListService.SearchVehicleCheckList(request).CreateFrom();
        }

        /// <summary>
        /// Delete Vehicle Check List 
        /// </summary>
        [ApiException]
        public Boolean Delete(VehicleCheckList vehicleCheckList)
        {
            if (vehicleCheckList == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            vehicleCheckListService.DeleteVehicleCheckList(vehicleCheckList.VehicleCheckListId);
            return true;
        }

        /// <summary>
        /// ADD/ Update Vehicle Check List
        /// </summary>
        [ApiException]
        public VehicleCheckList Post(VehicleCheckList vehicleCheckList)
        {
            if (vehicleCheckList == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleCheckListService.AddUpdateVehicleCheckList(vehicleCheckList.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}