using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using DomainRequestModel=Models.RequestModels;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tariff Rate Detail Api Controller
    /// </summary>
    public class GetTariffRateDetailController : ApiController
    {
         #region Private
        private readonly ITariffRateService tariffRateService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetTariffRateDetailController(ITariffRateService tariffRateService)
        {
            if (tariffRateService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("tariffRateService");
            }

            this.tariffRateService = tariffRateService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Detail Tariff Type
        /// </summary>
        /// <param name="tariffRateDetailRequest"></param>
        /// <returns></returns>
        public TariffRateDetailResponse Get(DomainRequestModel.TariffRateDetailRequest  tariffRateDetailRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffRateService.FindTariffRateById(tariffRateDetailRequest).CreateFrom();
        }

        #endregion
    }
}