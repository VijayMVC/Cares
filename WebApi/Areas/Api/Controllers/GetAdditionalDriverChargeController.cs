using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    [Authorize]
    public class GetAdditionalDriverChargeController : ApiController
    {
        #region Private

        private IWebApiAvailableRentalService WebApiAvailableRentalService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAdditionalDriverChargeController(IWebApiAvailableRentalService webApiAvailableRentalService)
        {
            if (webApiAvailableRentalService == null)
            {
                throw new ArgumentNullException("webApiAvailableRentalService");
            }
            WebApiAvailableRentalService = webApiAvailableRentalService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Available Services with their price
        /// </summary>        
        public IEnumerable<WebApiAdditionalDriverResponse> Post(WebApiGetAvailableServicesRequest request)
        {
            return WebApiAvailableRentalService.GetAdditionalDriverWithRates(request.DomainKey, request.TarrifTypeCode);
        }
        #endregion
    }
}