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
    /// Tariff Rate Detail Api Controller
    /// </summary>
    public class GetHireGroupDetailController : ApiController
    {
        #region Private
        private readonly ITariffRateService tariffRateService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetHireGroupDetailController(ITariffRateService tariffRateService)
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
        /// Get Hire group Detail For Tariff Rate
        /// </summary>
        /// <returns></returns>
        public HireGroupDetailResponse Get([FromUri]StandardRateMain standardRateMain)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffRateService.GetHireGroupDetailsForTariffRate(standardRateMain.StandardRtMainId).CreateFromHireGroupDetail();
        }

        #endregion
    }
}