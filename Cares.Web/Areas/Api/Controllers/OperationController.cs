using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Operation Controller
    /// </summary>
    public class OperationController : ApiController{
       
        #region Private
        private readonly IOperationService operationService;
        #endregion
        #region Constructor
        /// <summary>
        /// Operation Constructor
        /// </summary>
        public OperationController(IOperationService iOperationService)
        {
           operationService = iOperationService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get Operations
        /// </summary>
        public OperationSearchResponse Get([FromUri] OperationSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return operationService.SearchOperation(oppRequest).CreateFrom();
        }
        /// <summary>
        /// Delete Operation 
        /// </summary>
        public Boolean Delete(Operation oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            operationService.DeleteOperation(oppRequest.CreateFrom());
            return true;
        }
        /// <summary>
        ///  ADD/ Update Operation
        /// </summary>
        [ApiException]
        public Operation Post(Operation oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
         return operationService.SaveOperation(oppRequest.CreateFrom()).CreateFromm();
        }
        #endregion
    }
}