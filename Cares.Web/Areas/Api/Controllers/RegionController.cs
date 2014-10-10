using System;

using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using RegionSearchRequestResponse = Cares.Web.Models.RegionSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Region Controller
    /// </summary>
    public class RegionController : ApiController
    {
       #region Private
        private readonly IRegionService regionService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionController(IRegionService regionService)
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
        /// Get Regions
        /// </summary>
        public RegionSearchRequestResponse Get([FromUri] RegionSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return regionService.SearchRegion(request).CreateFrom();
        }

        /// <summary>
        /// Delete Region 
        /// </summary>
        [ApiException]
        public Boolean Delete(Region region)
        {
            if (region == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            regionService.DeleteRegion(region.RegionId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Region
        /// </summary>
        [ApiException]
        public Region Post(Region region)
        {
            if (region == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return regionService.SaveRegion(region.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}