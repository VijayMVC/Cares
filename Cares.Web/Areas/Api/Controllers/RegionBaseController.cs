using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Region Base Controller
    /// </summary>
    public class RegionBaseController : ApiController
    {
        #region Private
        private readonly IRegionService regionService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionBaseController(IRegionService regionService)
        {
            if (regionService == null)
            {
                throw new ArgumentNullException("regionService");
            }
            this.regionService = regionService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Regions Base Data
        /// </summary>
        public Models.RegionBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return regionService.LoadRegionBaseData().CreateFrom();
        }
        #endregion

    }
}