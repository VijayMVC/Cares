using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using  Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Insurance Rate Api Controller
    /// </summary>
    [Authorize]
    public class InsuranceRateBaseController : ApiController
    {
        #region Private
        private readonly IInsuranceRateService insuranceRateService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRateBaseController(IInsuranceRateService insuranceRateService)
        {
            if (insuranceRateService == null) throw new ArgumentNullException("insuranceRateService");
            this.insuranceRateService = insuranceRateService;
        }

        #endregion
        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public InsuranceRateBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return insuranceRateService.GetBaseData().CreateFromBaseResponse();
        }
        #endregion
    }
}