using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.WebApi.ModelMappers;
using Cares.WebApi.Models;

namespace Cares.WebApi.Areas.Api.Controllers
{
    /// <summary>
    /// Get Operation Workplace Controller
    /// </summary>
    [Authorize] 
    public class GetOperationWorkplaceController : ApiController
    {
        #region Private
        public IOperationsWorkPlaceService operationsWorkPlaceService { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetOperationWorkplaceController(IOperationsWorkPlaceService operationsWorkPlaceService)
        {
            if (operationsWorkPlaceService == null) throw new ArgumentNullException("operationsWorkPlaceService");
            this.operationsWorkPlaceService = operationsWorkPlaceService;
        }
        #endregion
        #region Public

        /// <summary>
        /// Get list of operational work places 
        /// </summary>
        public IEnumerable<WebApiOperationWorkplace> Post(WebApiGetOperationWorkplaceRequest request)
        {
            if (!ModelState.IsValid || request == null || !request.DomainKey.HasValue)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return
                operationsWorkPlaceService.GetOperationsWorkPlacesByDomainKey(request.DomainKey.Value).Select(owp => owp.CreateFrom());
        }
        #endregion
    }
}