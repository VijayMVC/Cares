using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tariff Rate Base Api Controller
    /// </summary>
    public class TariffRateBaseController : ApiController
    {
        #region Private
        private readonly ITariffRateService tariffRateService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffRateBaseController(ITariffRateService tariffRateService)
        {
            if (tariffRateService == null) throw new ArgumentNullException("tariffRateService");
            this.tariffRateService = tariffRateService;
        }

        #endregion
        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public TariffRateBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            var returnData = tariffRateService.GetBaseData().CreateFrom();
            return returnData;
        }
        #endregion

    }
}