using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using OperationWorkplaceSearchByIdResponse = Cares.Models.ResponseModels.OperationWorkplaceSearchByIdResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    public class OperationsWorkPlaceController : ApiController
    {
        #region Private
        private readonly IOperationsWorkPlaceService iOperationsWorkPlaceService;
        #endregion
        #region Constructor
        /// <summary>
        /// Operations WorkPlace Constructor
        /// </summary>
        public OperationsWorkPlaceController(IOperationsWorkPlaceService iOperationsWorkPlaceService)
        {
            this.iOperationsWorkPlaceService = iOperationsWorkPlaceService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get Operations
        /// </summary>
        public Models.OperationWorkplaceSearchByIdResponse Get([FromUri] long workPlaceId)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            Models.OperationWorkplaceSearchByIdResponse operationWorkplaceSearchByIdResponse = 
                iOperationsWorkPlaceService.GetOperationsWorkPlaceByWorkplaceId(workPlaceId).CreateFrommm();

            return operationWorkplaceSearchByIdResponse;
        }
        #endregion
    }
}