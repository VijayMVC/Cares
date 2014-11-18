using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Cares.Implementation.Services;
using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;

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
        public IEnumerable<WebApiAvailableInsurance> Post(GetAvailableServicesRequest request)
        {
            return webApiAvailableRentalService.GetAvailableInsurencesWithRates(request.DomainKey,
                request.TarrifTypeCode, request.StartDateTime);
        }
        #endregion
    }
}