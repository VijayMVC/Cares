using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Service Item Base Controller
    /// </summary>
    [Authorize]
    public class ServiceItemBaseController : ApiController
    {
        #region Private
        private readonly IServiceItemService serviceItemService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceItemBaseController(IServiceItemService serviceItemService)
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
        /// Get Service Item Base Data
        /// </summary>
        public Models.ServiceItemBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return serviceItemService.LoadServiceItemBaseData().CreateFrom();
        }
        #endregion
    }
}