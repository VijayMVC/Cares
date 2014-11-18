using System;
using System.Collections.Generic;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;

namespace Cares.WebApi.Areas.Api.Controllers
{
    /// <summary>
    /// Get Available Services
    /// </summary>
    public class GetAvailableChauffersRatesController : ApiController
    {
        #region Private
        private readonly IWebApiAvailableRentalService availableRentalService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAvailableChauffersRatesController(IWebApiAvailableRentalService availableRentalService)
        {
            if (availableRentalService == null)
            {
                throw new ArgumentNullException("availableRentalService");
            }
            this.availableRentalService = availableRentalService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get Available Services with their price
        /// </summary>        
        public IEnumerable<WebApiAvailableChauffer> Post(GetAvailableServicesRequest request)
        {
            return availableRentalService.GetAvailableChauffersWithRates(request.OutLocationId, request.StartDateTime,
                request.EndDateTime, request.DomainKey, request.HireGroupDetailId, request.TarrifTypeCode);
        }
        #endregion
    }
}