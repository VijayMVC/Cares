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
    /// Rental Agreement Vehicle CheckLists Api Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementVehicleCheckListController : ApiController
    {
        #region Private

        private readonly IVehicleCheckListService vehicleCheckListService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementVehicleCheckListController(IVehicleCheckListService vehicleCheckListService)
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
        /// Get CheckLists For Vehicle
        /// </summary>
        public IEnumerable<VehicleCheckList> Get([FromUri] GetRaVehicleCheckListRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return vehicleCheckListService.GetForVehicle(request.VehicleId).Select(hg => hg.CreateFrom());
        }

        #endregion
    }
}