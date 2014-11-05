using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Additional Charge For Nrt API Controller
    /// </summary>
    [Authorize]
    public class GetAdditionalChargeForNrtController : ApiController
    {
        #region Private
        private readonly INRTService nrtService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAdditionalChargeForNrtController(INRTService nrtService)
        {
            if (nrtService == null) throw new ArgumentNullException("nrtService");
            this.nrtService = nrtService;
        }

        #endregion

        #region Public

        /// <summary>
        /// Get Additional Charge For NRT
        /// </summary>
        [ApiException]
        public IEnumerable<AdditionalChargeForNrt> Post(GetAdditionalChargeForNrtRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return
                nrtService.AdditionalChargeForNrt(request.StartDate, request.VehicleId)
                    .Select(addCharge => addCharge.CreateFrom());

        }


        #endregion
    }
}