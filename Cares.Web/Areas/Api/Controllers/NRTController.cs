using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// NRT API Controller
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [Authorize]
    public class NRTController : ApiController
    {
        #region Private
        private readonly INRTService nrtService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public NRTController(INRTService nrtService)
        {
            if (nrtService == null) throw new ArgumentNullException("nrtService");
            this.nrtService = nrtService;
        }

        #endregion

        #region Public

        /// <summary>
        /// Add/Update a NRT
        /// </summary>
        [ApiException]
        public long Post(Models.NrtVehicle nrtVehicle)
        {
            if (nrtVehicle == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return nrtService.SaveNrt(nrtVehicle.CreateFrom());

        }


        #endregion
    }
}