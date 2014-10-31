using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Non Revenue Ticket Base API Controller
    /// </summary>
    // ReSharper disable once InconsistentNaming
    [Authorize]
    public class NRTBaseController : ApiController
    {
        #region Private

        private readonly INRTService nrtService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NRTBaseController(INRTService nrtService)
        {
            if (nrtService == null)
            {
                throw new ArgumentNullException("nrtService");
            }
            this.nrtService = nrtService;
        }

        #endregion

        #region Public
        /// <summary>
        /// Get Non Revenue Ticket Base Data
        /// </summary>
        public Models.NRTBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return nrtService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}