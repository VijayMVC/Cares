using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using AreaSearchRequestResponse = Cares.Web.Models.AreaSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Area Controller
    /// </summary>
    [Authorize]
    public class AreaController : ApiController
    {
       #region Private
        private readonly IAreaService areaService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaController(IAreaService areaService)
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
        /// Get Areas
        /// </summary>
        public AreaSearchRequestResponse Get([FromUri] AreaSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return areaService.SearchArea(request).CreateFrom();
        }

        /// <summary>
        /// Delete Area 
        /// </summary>
        [ApiException]
        public Boolean Delete(Area area)
        {
            if (area == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            areaService.DeleteArea(area.AreaId);
            return true;
        }

        /// <summary>
        /// ADD/ Update Area
        /// </summary>
        [ApiException]
        public Area Post(Area area)
        {
            if (area == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return areaService.SaveArea(area.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}