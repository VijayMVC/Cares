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
        /// Get Hire group Detail
        /// </summary>
        /// <param name="hireGroupDetailRequest"></param>
        /// <returns></returns>
        public HireGroupDetailResponse Get([FromUri]DomainRequestModel.HireGroupDetailRequest hireGroupDetailRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffRateService.GetHireGroupDetails(hireGroupDetailRequest).CreateFromHireGroupDetail();
        }

        #endregion
    }
}