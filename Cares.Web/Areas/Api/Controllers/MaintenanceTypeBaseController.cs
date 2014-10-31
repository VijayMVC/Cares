using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Maintenance Type Base Controller
    /// </summary>
    [Authorize]
    public class MaintenanceTypeBaseController : ApiController
    {
        #region Private
        private readonly IMaintenanceTypeService maintenanceTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public MaintenanceTypeBaseController(IMaintenanceTypeService maintenanceTypeService)
        {
            if (maintenanceTypeService == null)
            {
                throw new ArgumentNullException("maintenanceTypeService");
            }
            this.maintenanceTypeService = maintenanceTypeService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Maintenance Type Base Data
        /// </summary>
        public Models.MaintenanceTypeBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return maintenanceTypeService.LoadMaintenanceTypeBaseData().CreateFrom();
        }
        #endregion
    }
}