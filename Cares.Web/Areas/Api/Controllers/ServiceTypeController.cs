using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using ServiceTypeSearchRequestResponse = Cares.Web.Models.ServiceTypeSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Service Type Controller
    /// </summary>
    public class ServiceTypeController : ApiController
    {
       #region Private
        private readonly IServiceTypeService serviceTypeService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            if (serviceTypeService == null)
            {
                throw new ArgumentNullException("serviceTypeService");
            }
            this.serviceTypeService = serviceTypeService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Service Types
        /// </summary>
        public ServiceTypeSearchRequestResponse Get([FromUri] ServiceTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceTypeService.SearchServiceType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Service Type 
        /// </summary>
        [ApiException]
        public Boolean Delete(ServiceType serviceType)
        {
            if (serviceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            serviceTypeService.DeleteServiceType(serviceType.ServiceTypeId);
            return true;
        }

        /// <summary>
        ///  ADD / Update Service Type
        /// </summary>
        [ApiException]
        public ServiceType Post(ServiceType serviceType)
        {
            if (serviceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceTypeService.SaveServiceType(serviceType.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}