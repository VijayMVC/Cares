using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    /// <summary>
    /// Get available HireGroups controller
    /// </summary>
    [Authorize]
    public sealed class GetAvailableHireGroupsController : ApiController
    {
        #region Private
        private readonly IWebApiAvailableRentalService availableRentalService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAvailableHireGroupsController(IWebApiAvailableRentalService availableRentalService)
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
        /// Get Available HireGroup with their price
        /// </summary>        
        public IEnumerable<WebApiAvailableHireGroupsApiResponse> Post(WebApiGetAvailableHireGroupsRequest request)
        {
           return availableRentalService.GetAvailableHireGroupsWithRates(request.OutLocationId, request.StartDateTime,
                request.EndDateTime, request.DomainKey);
        } 
        #endregion

    }
}