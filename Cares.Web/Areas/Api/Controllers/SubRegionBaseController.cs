using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Sub Region Base Controller
    /// </summary>
    public class SubRegionBaseController : ApiController
    {
        #region Private
        private readonly ISubRegionService subRegionService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SubRegionBaseController(ISubRegionService subRegionService)
        {
            if (subRegionService == null)
            {
                throw new ArgumentNullException("subRegionService");
            }
            this.subRegionService = subRegionService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Sub Regions Base Data
        /// </summary>
        public Models.SubRegionBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return subRegionService.LoadSubRegionBaseData().CreateFrom();
        }
        #endregion

    }
}