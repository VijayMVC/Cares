using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Sub Region Controller
    /// </summary>
    [Authorize]
    public class SubRegionController : ApiController
    {
       #region Private
        private readonly ISubRegionService subRegionService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SubRegionController(ISubRegionService subRegionService)
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
        /// Get Sub Regions 
        /// </summary>
        public Models.SubRegionSearchRequestResponse Get([FromUri] SubRegionSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            Cares.Models.RequestModels.SubRegionSearchRequestResponse response = subRegionService.SearchSubRegion(request);
            return response.CreateFrom();
           
        }

        /// <summary>
        /// Delete Sub Region 
        /// </summary>
        [ApiException]
        public Boolean Delete(SubRegion subRegion)
        {
            if (subRegion == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            subRegionService.DeleteSubRegion(subRegion.SubRegionId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Sub Region
        /// </summary>
        [ApiException]
        public SubRegion Post(SubRegion subRegion)
        {
            if (subRegion == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return subRegionService.SaveSubRegion(subRegion.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}