using System;
using System.Collections.Generic;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;

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
        [HttpPost]
        public IEnumerable<WebApiAvailaleHireGroup> Post(GetAvailableHireGroupsRequest request)
        {
            var returnList = availableRentalService.GetAvailableHireGroupsWithRates(request.OutLocationId, request.StartDateTime,
                request.EndDateTime, request.DomainKey);
            return returnList;
        } 
        #endregion

    }
}