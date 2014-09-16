using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Service Rate Base Api Controller
    /// </summary>
    public class ServiceRtBaseController : ApiController
    {
        #region Private
        private readonly IServiceRtService serviceRtService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRtBaseController(IServiceRtService serviceRtService)
        {
            if (serviceRtService == null) throw new ArgumentNullException("serviceRtService");
            this.serviceRtService = serviceRtService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public ServiceRateBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceRtService.GetBaseData().CreateFrom();
        }
        #endregion

    }
}