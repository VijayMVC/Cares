using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Service Item Controller
    /// </summary>
    [Authorize]
    public class ServiceItemController : ApiController
    {
       #region Private
        private readonly IServiceItemService serviceItemService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceItemController(IServiceItemService serviceItemService)
        {
            if (serviceItemService == null)
            {
                throw new ArgumentNullException("serviceItemService");
            }
            this.serviceItemService = serviceItemService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Service Items
        /// </summary>
        public ServiceItemSearchRequestResponse Get([FromUri] ServiceItemSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceItemService.SearchServiceItem(request).CreateFrom();
        }

        /// <summary>
        /// Delete Service Item 
        /// </summary>
        [ApiException]
        public Boolean Delete(ServiceItem serviceItem)
        {
            if (serviceItem == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            serviceItemService.DeleteServiceItem(serviceItem.ServiceItemId);
            return true;
        }

        /// <summary>
        /// ADD/ Update Service Item
        /// </summary>
        [ApiException]
        public ServiceItem Post(ServiceItem serviceItem)
        {
            if (serviceItem == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceItemService.SaveServiceItem(serviceItem.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}