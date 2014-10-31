using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Service Items Api Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementServiceItemsController : ApiController
    {
        #region Private

        private readonly IServiceItemService serviceItemService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementServiceItemsController(IServiceItemService serviceItemService)
        {
            if (serviceItemService == null)
            {
                throw new ArgumentNullException("serviceItemService");
            }
            this.serviceItemService = serviceItemService;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get Service Items
        /// </summary>
        public IEnumerable<ServiceItem> Get()
        {
            return serviceItemService.GetAll().Select(si => si.CreateFrom());
        }

        #endregion
    }
}