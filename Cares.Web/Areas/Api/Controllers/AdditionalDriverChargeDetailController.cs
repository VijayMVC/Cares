using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Additional Driver Charge Detail Api Controller
    /// </summary>
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
        public AdditionalDriverCharge Get([FromUri]AdditionalDriverCharge additionalDriverCharge)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            //return additionalDriverService.GetAdditionalDriverChargeDetail(additionalDriverCharge.AdditionalDriverChargeId).CreateFromEmployeeDetail();
            return null;
        }

        #endregion

    }
}