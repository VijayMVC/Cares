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
    /// Get Operation Workplace
    /// </summary>
    [Authorize]
    public class GetOperationWorkplaceController : ApiController
    {
        public IOperationsWorkPlaceService operationsWorkPlaceService { get; set; }

        public GetOperationWorkplaceController(IOperationsWorkPlaceService operationsWorkPlaceService)
        {
            if (operationsWorkPlaceService == null) throw new ArgumentNullException("operationsWorkPlaceService");
            this.operationsWorkPlaceService = operationsWorkPlaceService;
        }

        [HttpGet]
        public IEnumerable<WebApiOperationWorkplace> Get(long domainKey)
        {
            if (!ModelState.IsValid || domainKey == 0)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return
                operationsWorkPlaceService.GetOperationsWorkPlacesByDomainKey(domainKey).Select(owp => owp.CreateFrom());
        } 
    }
}