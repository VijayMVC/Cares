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
    /// Insurance Rate Detail Api Controller
    /// </summary>
    [Authorize]
    public class InsuranceRtDetailController : ApiController
    {
        #region Private
        private readonly IInsuranceRateService insuranceRateService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRtDetailController(IInsuranceRateService insuranceRateService)
        {
            if (insuranceRateService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("insuranceRateService");
            }

            this.insuranceRateService = insuranceRateService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Insurance Rate for Insurance Rate Main
        /// </summary>
        /// <returns></returns>
        public InsuranceRtDetailResponse Get([FromUri]InsuranceRtMainContent insuranceRtMainContent)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return insuranceRateService.GetInsuranceRtDetail(insuranceRtMainContent.InsuranceRtMainId).CreateFrom();
        }

        #endregion
    }
}