using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Operation Base Controller
    /// </summary>
    public class OperationBaseController : ApiController
    {
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
        #region Public
        /// <summary>
        /// Get Operation Base data
        /// </summary>
        public Models.OperationBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return operationService.LoadOperationBaseData().CreateFrom();
        }
        #endregion
    }
}