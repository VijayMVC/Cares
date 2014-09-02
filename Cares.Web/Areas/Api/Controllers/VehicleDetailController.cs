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
    /// Vehicle Detail API Controller
    /// </summary>
    public class VehicleDetailController : ApiController
    {
         #region Private

        private readonly IVehicleService vehicleService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleDetailController(IVehicleService vehicleService)
        {
            if (vehicleService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("vehicleService");
            }

            this.vehicleService = vehicleService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Vehicle Detail
        /// </summary>
        /// <returns></returns>
        public VehicleDetail Get([FromUri]VehicleDetail vehicleDetail)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return vehicleService.GetVehicleDetail(vehicleDetail.VehicleId).CreateFromDetail();
        }

        #endregion

    }
}