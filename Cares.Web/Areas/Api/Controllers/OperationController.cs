using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    public class OperationController : ApiController{

        #region Constructor
        public OperationController(IOperationService iOperationService)
        {
           operationService = iOperationService;
        }
        #endregion
        #region Private
        private readonly IOperationService operationService;
        #endregion
        public OperationSearchResponse Get([FromUri] OperationSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return operationService.SearchOperation(oppRequest).CreateFrom();
        }
        public Boolean Delete(Models.Operation oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            operationService.DeleteOperation(oppRequest.CreateFrom());
            return true;
        }
        public Models.Operation Post(Models.Operation oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
         return operationService.SaveOperation(oppRequest.CreateFrom()).CreateFromm();
        }   
    }
}