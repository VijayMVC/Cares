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
    ///  Maintenece Type Group Controller
    /// </summary>
    public class MainteneceTypeGroupController : ApiController
    {
       #region Private
        private readonly IMainteneceTypeGroupService mainteneceTypeGroupService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MainteneceTypeGroupController(IMainteneceTypeGroupService mainteneceTypeGroupService)
        {
            if (mainteneceTypeGroupService == null)
            {
                throw new ArgumentNullException("mainteneceTypeGroupService");
            }
            this.mainteneceTypeGroupService = mainteneceTypeGroupService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Maintenece Type Groups
        /// </summary>
        public MainteneceTypeGroupSearchRequestResponse Get([FromUri] MainteneceTypeGroupSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return mainteneceTypeGroupService.SearchMainteneceTypeGroup(request).CreateFrom();
        }

        /// <summary>
        /// Delete  Maintenece Type Group 
        /// </summary>
        [ApiException]
        public Boolean Delete(MaintenanceTypeGroup maintenanceTypeGroup)
        {
            if (maintenanceTypeGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            mainteneceTypeGroupService.DeleteMainteneceTypeGroup(maintenanceTypeGroup.DocumentGroupId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update  Maintenece Type Group
        /// </summary>
        [ApiException]
        public MaintenanceTypeGroup Post(MaintenanceTypeGroup maintenanceTypeGroup)
        {
            if (maintenanceTypeGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return mainteneceTypeGroupService.SaveMaintenanceTypeGroup(maintenanceTypeGroup.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}