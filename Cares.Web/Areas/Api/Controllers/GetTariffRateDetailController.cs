using System;
using System.Collections.Generic;
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
            if (tariffRateService == null)
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
            return tariffRateService.FindTariffRateById(id).CreateFrom();
        }

        #endregion
    }
}