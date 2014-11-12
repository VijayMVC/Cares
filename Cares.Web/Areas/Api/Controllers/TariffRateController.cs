using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using DomainRequestModels = Cares.Models.RequestModels;
using DomainModels = Cares.Models.DomainModels;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tariff Rate Api Controller
    /// </summary>
    [Authorize]
    public class TariffRateController : ApiController
    {
        #region Private
        private readonly ITariffRateService tariffRateService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffRateController(ITariffRateService tariffRateService)
        {
            if (tariffRateService == null)
            {
                throw new ArgumentNullException("tariffRateService");
            }

            this.tariffRateService = tariffRateService;


        }
        #endregion

        #region Public

        // GET api/<controller>
        public TariffRateSearchResponse Get([FromUri] DomainRequestModels.TariffRateSearchRequest request)
        {
            if (request == null && !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffRateService.LoadTariffRates((request)).CreateFrom();
        }
        /// <summary>
        /// Update a Tariff Rate
        /// </summary>
        [ApiException]
        public TariffRateContent Post(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            TariffRateContent tariffRateContent = tariffRateService.SaveTariffRate(standardRateMain.CreateFrom()).CreateFrom();
            return tariffRateContent;
        }


        /// <summary>
        /// Delete a Tariff Rate
        /// </summary>
        [ApiException]
        public void Delete(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            tariffRateService.DeleteTariffRate(standardRateMain.StandardRtMainId);
        }

        #endregion
    }
}