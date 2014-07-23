using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;

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
        /// Get Detail Tariff Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TariffRateDetailResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffRateService.FindTariffRateById(id).CreateFrom();
        }

        #endregion
    }
}