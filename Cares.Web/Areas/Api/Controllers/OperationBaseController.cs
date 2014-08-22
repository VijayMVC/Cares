using System;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using OperationBaseDataResponse = Cares.Models.ResponseModels.OperationBaseDataResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    public class OperationBaseController : ApiController
    {
         #region Public
        public Models.OperationBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return operationService.LoadOperationBaseData().CreateFrom();
        }
        #endregion
        #region Private

        private readonly IOperationService operationService;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OperationBaseController(IOperationService operationService)
        {
            if (operationService == null)
            {
                throw new ArgumentNullException("operationService");
            }
            this.operationService = operationService;
        }

        #endregion
    }
}