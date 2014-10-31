using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Area Base Controller
    /// </summary>
    [Authorize]
    public class AreaBaseController : ApiController
    {
        #region Private
        private readonly IAreaService areaService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaBaseController(IAreaService areaService)
        {
            if (areaService == null)
            {
                throw new ArgumentNullException("areaService");
            }
            this.areaService = areaService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Area Base Data
        /// </summary>
        public Models.AreaBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return areaService.LoadAreaBaseData().CreateFrom();
        }
        #endregion
    }
}