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
    /// Business Partner Relationship Type Controller
    /// </summary>
    public class BusinessPartnerRelationshipTypeController : ApiController
    {
       #region Private
       private readonly IBusinessPartnerRelationTypeService businessPartnerRelationTypeService;
       #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerRelationshipTypeController(IBusinessPartnerRelationTypeService businessPartnerRelationTypeService)
        {
            if (businessPartnerRelationTypeService == null)
            {
                throw new ArgumentNullException("businessPartnerRelationTypeService");
            }
            this.businessPartnerRelationTypeService = businessPartnerRelationTypeService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Business Partner Relation Types
        /// </summary>
        public Models.BusinessPartnerRelationTypeSearchRequestResponse Get([FromUri] BusinessPartnerRelationTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessPartnerRelationTypeService.SearchBusinessPartnerRelationType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Business Partner Relation Type
        /// </summary>
        [ApiException]
        public Boolean Delete(BusinessPartnerRelationshipType businessPartnerRelationshipType)
        {
            if (businessPartnerRelationshipType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            businessPartnerRelationTypeService.DeleteBusinessPartnerRelationType(businessPartnerRelationshipType.BusinessPartnerRelationshipTypeId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Business Partner Relation Type
        /// </summary>
        [ApiException]
        public BusinessPartnerRelationshipType Post(BusinessPartnerRelationshipType businessPartnerRelationshipType)
        {
            if (businessPartnerRelationshipType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessPartnerRelationTypeService.SaveBusinessPartnerRelationType(businessPartnerRelationshipType.CreateFromm()).CreateFromm();
        }

        #endregion
    }
}