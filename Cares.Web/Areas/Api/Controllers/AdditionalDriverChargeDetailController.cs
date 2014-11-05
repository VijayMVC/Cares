using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Additional Driver Charge Detail Api Controller
    /// </summary>
    [Authorize]
    public class AdditionalDriverChargeDetailController : ApiController
    {

        #region Private

        private readonly IAdditionalDriverService additionalDriverService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeDetailController(IAdditionalDriverService additionalDriverService)
        {
            if (additionalDriverService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("additionalDriverService");
            }

            this.additionalDriverService = additionalDriverService;
        }
        #endregion

        #region Public
        /// <summary>
        ///  Additional Driver Charge Detail
        /// </summary>
        /// <returns></returns>
        public List<Models.AdditionalDriverCharge> Get([FromUri]AdditionalDriverCharge additionalDriverCharge)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            List<AdditionalDriverCharge> result =
                additionalDriverService.GetAdditionalDriverChargeDetail(additionalDriverCharge.AdditionalDriverChargeId).ToList();
            return result.Count>0?result.Select(x => x.CreateFrom()).ToList():null;
        }

        #endregion

    }
}