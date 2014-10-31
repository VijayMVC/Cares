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
    /// Service Rate Detail Api Controller
    /// </summary>
    [Authorize]
    public class ServiceRtDetailController : ApiController
    {
        #region Private

        private readonly IServiceRtService serviceRtService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtDetailController(IServiceRtService serviceRtService)
        {
            if (serviceRtService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("serviceRtService");
            }

            this.serviceRtService = serviceRtService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Service Rate Detail
        /// </summary>
        /// <returns></returns>
        public ServiceRtDetailResponse Get([FromUri]ServiceRtDetailContent serviceRtDetailContent)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceRtService.GetServiceRtDetail(serviceRtDetailContent.ServiceRtMainId).CreateFrom();
        }

        #endregion
    }
}