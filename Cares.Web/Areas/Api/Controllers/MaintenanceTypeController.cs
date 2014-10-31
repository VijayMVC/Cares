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
    /// Maintenance Type API Controller
    /// </summary>
    [Authorize]
    public class MaintenanceTypeController : ApiController
    {  
        #region Private
        /// <summary>
        /// Maintenance Type Service 
        /// </summary>
        private readonly IMaintenanceTypeService maintenanceTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MaintenanceTypeController(IMaintenanceTypeService maintenanceTypeService)
        {
            this.maintenanceTypeService = maintenanceTypeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Maintenance Types
        /// </summary>
        public MaintenanceTypeSearchRequestResponse Get([FromUri] MaintenanceTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  maintenanceTypeService.SearchMaintenanceType(request).CreateFrom();
        }

        /// <summary>
        /// Delete Maintenance Type
        /// </summary>
        [ApiException]
        public Boolean Delete(MaintenanceType maintenanceType)
        {
            if (maintenanceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            maintenanceTypeService.DeleteMaintenanceType(maintenanceType.MaintenanceTypeId);
            return true;
        }

        /// <summary>
        /// Add/ Update Maintenance Type
        /// </summary>
        [ApiException]
        public MaintenanceType Post(MaintenanceType maintenanceType)
        {
            if (maintenanceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return maintenanceTypeService.AddUpdateMaintenanceType(maintenanceType.CreateFrom()).CreateFrom();
        }
        #endregion
    }
} 