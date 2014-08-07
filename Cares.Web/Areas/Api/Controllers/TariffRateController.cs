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
        public TariffRateSearchResponse Get([FromUri] DomainModels.TariffRateRequest request)
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
        public TariffRateContent Post(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            TariffRateContent tariffRateContent = tariffRateService.Update(standardRateMain.CreateFrom()).CreateFrom();
            if (standardRateMain.HireGroupDetailsInStandardRtMain != null)
            {
                foreach (var standardRate in standardRateMain.HireGroupDetailsInStandardRtMain)
                {
                    standardRate.StandardRtMainId = standardRateMain.StandardRtMainId;
                    tariffRateService.AddStandardRate(standardRate.CreateFrom());
                }
            }
            return tariffRateContent;
        }

        /// <summary>
        /// Add a Tariff Rate
        /// </summary>
        public TariffRateContent Put(StandardRateMain standardRateMain)
        {
            DateTime a, b, c, d;
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            a = Convert.ToDateTime(standardRateMain.StartDt);
            b = Convert.ToDateTime(standardRateMain.EndDt);
            if (a.Date < System.DateTime.Now.Date)
               // throw new CaresBusinessException("Pricing-InvalidStartDate", null);
            if (b.Date < a.Date)
               // throw new CaresBusinessException("Pricing-InvalidEndDate", null);

            tariffRateService.FindByTariffTypeCode(standardRateMain.TariffTypeCode);

            TariffRateContent tariffRateContent = tariffRateService.AddTariffRate(standardRateMain.CreateFrom()).CreateFrom();
            if (standardRateMain.HireGroupDetailsInStandardRtMain != null)
            {
                foreach (var standardRate in standardRateMain.HireGroupDetailsInStandardRtMain)
                {
                    standardRate.StandardRtMainId = tariffRateContent.StandardRtMainId;
                    tariffRateService.AddStandardRate(standardRate.CreateFrom());
                }
            }
            return tariffRateContent;
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