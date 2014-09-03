using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Operations Work Place Controller
    /// </summary>
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
            return 
            iOperationsWorkPlaceService.GetOperationsWorkPlaceByWorkplaceId(workPlaceId).CreateFrommm();
        }
        #endregion
    }
}