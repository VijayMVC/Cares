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
            tariffRateService.DeleteTariffRate(tariffRateService.Find(standardRateMain.StandardRtMainId));
        }

        /// <summary>
        /// Standard Rate Validation
        /// </summary>
        /// <param name="standardRateMain"></param>
        /// <param name="addFlag"></param>
        private void StandardRateValidation(StandardRateMain standardRateMain, bool addFlag)
        {
            DateTime a, b, c, d;
            a = Convert.ToDateTime(standardRateMain.StartDt);
            b = Convert.ToDateTime(standardRateMain.EndDt);
            if (addFlag)
            {
                if (a.Date < DateTime.Now.Date)
                    throw new Exception();
                //throw new CaresBusinessException("Pricing-InvalidStartDate", null);
                if (b.Date < a.Date)
                    throw new Exception();
                //throw new CaresBusinessException("Pricing-InvalidEndDate", null);
                DomainModels.TariffType tariffType = tariffRateService.FindTariffTypeById(standardRateMain.TariffTypeId);
                IEnumerable<DomainModels.StandardRateMain> oStRateMain = tariffRateService.FindByTariffTypeCode(tariffType.TariffTypeCode).Select(s => s);
                foreach (var rateMain in oStRateMain)
                {
                    c = rateMain.StartDt;
                    d = rateMain.EndDt;

                    if ((a <= c) && ((d) <= (b)))
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-ExistingStandardRtOverlaps", null);
                    if ((c <= a) && ((b) <= (d)))
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-CurrentStandardRtOverlaps", null);
                    if ((c <= a) && (a <= (d)) && ((d) <= (b)))
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-StartStandardRtDurationOverlaps", null);
                    if ((a <= c) && (c <= (b)) && ((b) <= (d)))
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-EndStandardRtDurationOverlaps", null);
                }
            }
            if (standardRateMain.HireGroupDetailsInStandardRtMain != null)
            {
                foreach (var standardRate in standardRateMain.HireGroupDetailsInStandardRtMain)
                {
                    c = Convert.ToDateTime(standardRate.StartDate);
                    d = Convert.ToDateTime(standardRate.EndDt);
                    if (c.Date < DateTime.Now.Date || d.Date < DateTime.Now.Date)
                        throw new Exception();
                    // throw new CaresBusinessException("Pricing-StRateInvalidEffectiveDates", null);
                    if (d < c)
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-StRateInvalidEndDate", null);
                    if (c < a || d > b)
                        throw new Exception();
                    //throw new CaresBusinessException("Pricing-StRateInvalidRangeEffectiveDate", null);
                }
            }

        }

        #endregion
    }
}