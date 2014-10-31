using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Legal Status API Controller
    /// </summary>
    [Authorize]
    public class BusinessLegalStatusController : ApiController
    {  
        #region Private
        /// <summary>
        /// Business Legal Status Service 
        /// </summary>
        private readonly IBusinessLegalStatusService businessLegalStatusService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessLegalStatusController(IBusinessLegalStatusService businessLegalStatusService)
        {
            this.businessLegalStatusService = businessLegalStatusService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Business Legal Statuses
        /// </summary>
        public BusinessLegalStatusSearchRequestRespose Get([FromUri] BusinessLegalStatusSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessLegalStatusService.SearchBusinessLegalStatus(request).CreateFrom();
        }

        /// <summary>
        /// Delete Business Legal Status
        /// </summary>
        [ApiException]
        public Boolean Delete(BusinessLegalStatus request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            businessLegalStatusService.DeleteBusinessLegalStatus(request.BusinessLegalStatusId);
            return true;
        }

        /// <summary>
        /// Add/ Update Business Legal Status
        /// </summary>
        [ApiException]
        public BusinessLegalStatus Post(BusinessLegalStatus request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessLegalStatusService.AddUpdateBusinessLegalStatus(request.CreateFromm()).CreateFromm();
        }
        #endregion
    }
} 