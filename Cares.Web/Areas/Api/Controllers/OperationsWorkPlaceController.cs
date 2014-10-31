using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Operations Work Place Controller
    /// </summary>
    [Authorize]
    public class OperationsWorkPlaceController : ApiController
    {
        #region Private
        private readonly IOperationsWorkPlaceService operationsWorkPlaceService;
        #endregion
        #region Constructor
        /// <summary>
        /// Operations WorkPlace Constructor
        /// </summary>
        public OperationsWorkPlaceController(IOperationsWorkPlaceService operationsWorkPlaceService)
        {
            this.operationsWorkPlaceService = operationsWorkPlaceService;
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
            operationsWorkPlaceService.GetOperationsWorkPlaceByWorkplaceId(workPlaceId).CreateFrommm();
        }
        #endregion
    }
}