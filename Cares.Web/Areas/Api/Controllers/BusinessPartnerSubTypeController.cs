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
    /// Business Partner Sub Type API Controller
    /// </summary>
    public class BusinessPartnerSubTypeController : ApiController
    {  
        #region Private
        /// <summary>
        /// Business Partner Sub Type 
        /// </summary>
        private readonly IBusinessPartnerSubTypeService businessPartnerSubTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerSubTypeController(IBusinessPartnerSubTypeService businessPartnerSubTypeService)
        {
            this.businessPartnerSubTypeService = businessPartnerSubTypeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Business Partner Sub Types
        /// </summary>
        public BusinessPartnerSubTypeSearchRequestResponse Get([FromUri] BusinessPartnerSubTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  businessPartnerSubTypeService.SearchBusinessPartnerSubType(request).CreateFrom();
        }

        /// <summary>
        /// Delete  Business Partner Sub Type
        /// </summary>
        [ApiException]
        public Boolean Delete(BusinessPartnerSubType request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            businessPartnerSubTypeService.DeleteBusinessPartnerSubType(request.BusinessPartnerSubTypeId);
            return true;
        }

        /// <summary>
        /// Add/ Update  Business Partner Sub Type
        /// </summary>
        [ApiException]
        public BusinessPartnerSubType Post(BusinessPartnerSubType request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return businessPartnerSubTypeService.AddUpdateBusinessPartnerSubType(request.CreateFrom()).CreateFromm();
        }
        #endregion
    }
} 