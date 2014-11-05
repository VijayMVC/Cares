using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    [Authorize]
    public class OrganizationGroupController : ApiController
    {
        #region Private
        private readonly IOrganizationGroupService orgGroupService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OrganizationGroupController(IOrganizationGroupService orgGroupService)
        {
            if (orgGroupService == null)
            {
                throw new ArgumentNullException("orgGroupService");
            }
            this.orgGroupService = orgGroupService;
        }

        #endregion
        #region Public

        /// <summary>to
        /// Get OrgGroups
        /// </summary>
        public OrgGroupRequestResponse Get([FromUri] OrgGroupSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return orgGroupService.SerchOrgGroup(request).CreateFrom();
        }

        /// <summary>
        /// Delete org group
        /// </summary>
        [ApiException]
        public Boolean Delete(OrgGroup orgGroup)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            orgGroupService.DeleteOrgGroup(orgGroup.OrgGroupId);
            return false;
        }

        /// <summary>
        /// Add/Update org group
        /// </summary>
        [ApiException]
        public OrgGroup Post(OrgGroup orgGroup)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return orgGroupService.AddUpdateOrgGroup((orgGroup).CreateFrom()).CreateFromm();
        }

        #endregion 
    }
}