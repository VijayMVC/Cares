using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Additional Driver Base Api Controller
    /// </summary>
    [Authorize]
    public class AdditionalDriverChargeBaseController : ApiController
    {
        #region Private

        private readonly IAdditionalDriverService additionalDriverService;

        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeBaseController(IAdditionalDriverService additionalDriverService)
        {
            if (additionalDriverService == null)
            {
                throw new ArgumentNullException("additionalDriverService");
            }
            this.additionalDriverService = additionalDriverService;
        }

        #endregion
        
        #region Public
        /// <summary>
        /// Get AdditionalDriver Charge Base Data
        /// </summary>
        public Models.AdditionalDriverChargeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalDriverService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}