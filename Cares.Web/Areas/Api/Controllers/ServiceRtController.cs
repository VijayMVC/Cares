using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using DomainRequestModels = Cares.Models.RequestModels;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Service Rate Api Controller
    /// </summary>
    [Authorize]
    public class ServiceRtController : ApiController
    {
        #region Private
        private readonly IServiceRtService serviceRtService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtController(IServiceRtService serviceRtService)
        {
            if (serviceRtService == null)
            {
                throw new ArgumentNullException("serviceRtService");
            }

            this.serviceRtService = serviceRtService;


        }
        #endregion

        #region Public

        // GET api/<controller>
        public ServiceRateSearchResponse Get([FromUri] DomainRequestModels.ServiceRateSearchRequest request)
        {
            if (request == null && !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceRtService.LoadServiceRates((request)).CreateFrom();
        }

        /// <summary>
        /// Update/Update a Service Rate
        /// </summary>
        [ApiException]
        public ServiceRtMainContent Post(ServiceRtMainContent serviceRtMainContent)
        {
            if (serviceRtMainContent == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            ServiceRtMainContent serviceRtMainContentResponse = serviceRtService.SaveServiceRate(serviceRtMainContent.CreateFrom()).CreateFrom();
            return serviceRtMainContentResponse;
        }

        /// <summary>
        /// Delete a Insurance Rate
        /// </summary>
        [ApiException]
        public void Delete(ServiceRtMainContent serviceRtMainContent)
        {
            if (serviceRtMainContent == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            serviceRtService.DeleteServiceRate(serviceRtMainContent.ServiceRtMainId);
        }
        #endregion
    }
}