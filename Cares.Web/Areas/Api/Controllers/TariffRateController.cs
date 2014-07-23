using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using DomainModels = Models.RequestModels;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tariff Rate Api Controller
    /// </summary>
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
        public TariffRateResponse Get([FromUri] DomainModels.TariffRateRequest request)
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
        public StandardRateMain Post(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tariffRateService.Update(standardRateMain.CreateFrom()).CreateFrom();
        }

        /// <summary>
        /// Adds a Tariff Rate
        /// </summary>
        public StandardRateMain Put(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tariffRateService.AddTariffRate(standardRateMain.CreateFrom()).CreateFrom();
        }

        /// <summary>
        /// Delete a Tariff Rate
        /// </summary>
        public void Delete(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            tariffRateService.DeleteTariffRate(tariffRateService.Find(standardRateMain.StandardRtMainId));
        }
        #endregion
    }
}