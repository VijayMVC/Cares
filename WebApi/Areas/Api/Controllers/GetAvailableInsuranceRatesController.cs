using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    public class GetAvailableInsuranceRatesController : ApiController
    {
        #region Private

        private IWebApiAvailableRentalService webApiAvailableRentalService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAvailableInsuranceRatesController(IWebApiAvailableRentalService webApiAvailableRentalService)
        {
            if (webApiAvailableRentalService == null)
            {
                throw new ArgumentNullException("webApiAvailableRentalService");
            }
            this.webApiAvailableRentalService = webApiAvailableRentalService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Available Services with their price
        /// </summary>        
        public IEnumerable<WebApiAvailableInsurance> Post(WebApiGetAvailableServicesRequest request)
        {
            return webApiAvailableRentalService.GetAvailableInsurencesWithRates(request.DomainKey,
                request.TarrifTypeCode, request.StartDateTime);
        }
        #endregion
    }
}