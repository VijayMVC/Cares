using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{

    /// <summary>
    /// Additional Charge Base API Controller
    /// </summary>
    [Authorize]
    public class AdditionalChargeBaseController : ApiController
    {
        #region Private

        private readonly IAdditionalChargeService additionalChargeService;

        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeBaseController(IAdditionalChargeService additionalChargeService)
        {
            if (additionalChargeService == null)
            {
                throw new ArgumentNullException("additionalChargeService");
            }
            this.additionalChargeService = additionalChargeService;
        }

        #endregion
        
        #region Public
        /// <summary>
        /// Get Additional Charge Base Data
        /// </summary>
        public Models.AdditionalChargeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalChargeService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}