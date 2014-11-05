using Cares.Interfaces.IServices;
using System;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// WorkPlace Type Base Controller
    /// </summary>
    [Authorize]
    public class WorkplaceTypeBaseController : ApiController
    {
        #region Private
        private readonly IWorkplaceTypeService workplaceTypeService;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkplaceTypeBaseController(IWorkplaceTypeService workplaceTypeService)
        {
            if (workplaceTypeService == null)
            {
                throw new ArgumentNullException("workplaceTypeService");
            }
            this.workplaceTypeService = workplaceTypeService;
        }

        #endregion
        #region Public
      
        #endregion
    }
}