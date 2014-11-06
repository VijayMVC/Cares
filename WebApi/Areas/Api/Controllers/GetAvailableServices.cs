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
    public class GetAvailableServices : ApiController
    {
        #region Private
        private readonly IWebApiAvailableRentalService availableRentalService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAvailableServices(IWebApiAvailableRentalService availableRentalService)
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
        public IEnumerable<WebApiAvailaleHireGroup> Post(GetAvailableHireGroupsRequest request)
        {
            var returnList = availableRentalService.GetAvailableHireGroupsWithRates(request.OutLocationId, request.StartDateTime,
                request.EndDateTime, request.DomainKey);
            return returnList;
        }

        /// <summary>
        /// Get Available HireGroup with their price
        /// </summary>        
        public IEnumerable<WebApiAvailableServices> Post(GetAvailableServicesRequest request)
        {
            var returnList = availableRentalService.GetAvailableServicesWithRates(request.OutLocationId, request.StartDateTime,
                request.EndDateTime, request.DomainKey,request.HireGroupDetailId);
            return returnList;
        } 
        #endregion
    }
}