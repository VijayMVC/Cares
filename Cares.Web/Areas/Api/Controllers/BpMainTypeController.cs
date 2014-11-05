using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Main Type Controller
    /// </summary>
    [Authorize]
    public class BpMainTypeController : ApiController
    {
       #region Private
        private readonly IBpMainTypeService bpMainTypeService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BpMainTypeController(IBpMainTypeService bpMainTypeService)
        {
            if (bpMainTypeService == null)
            {
                throw new ArgumentNullException("bpMainTypeService");
            }
            this.bpMainTypeService = bpMainTypeService;
        }
        #endregion
       #region Public

        /// <summary>
        /// Get Business Partner Main Types
        /// </summary>
        public Models.BpMainTypeSearchRequestResponse Get([FromUri] BpMainTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return bpMainTypeService.SearchBpMainType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Business Partner Main Type
        /// </summary>
        [ApiException]
        public Boolean Delete(Models.BusinessPartnerMainType businessPartnerMainType)
        {
            if (businessPartnerMainType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            bpMainTypeService.DeleteBpMainType(businessPartnerMainType.BusinessPartnerMainTypeId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Business Partner Main Type
        /// </summary>
        [ApiException]
        public Models.BusinessPartnerMainType Post(Models.BusinessPartnerMainType documentGroup)
        {
            if (documentGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return bpMainTypeService.SaveBpMainType(documentGroup.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}