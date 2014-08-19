using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using DomainRequestModels = Cares.Models.RequestModels;
using Cares.Web.Models;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Insurance Rate Api Controller
    /// </summary>
    public class InsuranceRateController : ApiController
    {
        #region Private
        private readonly IInsuranceRateService insuranceRateService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceRateController(IInsuranceRateService insuranceRateService)
        {
            if (insuranceRateService == null)
            {
                throw new ArgumentNullException("insuranceRateService");
            }

            this.insuranceRateService = insuranceRateService;


        }
        #endregion
        #region Public
        // GET api/<controller>
        public InsuranceRateSearchResponse Get([FromUri] DomainRequestModels.InsuranceRateSearchRequest request)
        {
            if (request == null && !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return insuranceRateService.LoadInsuranceRates((request)).CreateFromSearchResponse();
        }
        /// <summary>
        /// Update/Update a Insurance Rate
        /// </summary>
        public InsuranceRtMainContent Post(InsuranceRtMainContent insuranceRtMainContent)
        {
            if (insuranceRtMainContent == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            InsuranceRtMainContent insuranceRtContent = insuranceRateService.SaveInsuranceRate(insuranceRtMainContent.CreateFrom()).CreateFrom();
            return insuranceRtContent;
        }


        /// <summary>
           /// Delete a Insurance Rate
        /// </summary>
        public void Delete(StandardRateMain standardRateMain)
        {
            if (standardRateMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            insuranceRateService.DeleteInsuranceRate(insuranceRateService.FindById(standardRateMain.StandardRtMainId));
        }
        #endregion
    }
}