using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cares.WebApi.Areas.Api.Controllers
{
    public class GetAdditionalDriverChargeController : ApiController
    {

        #region Private

        private IWebApiAvailableRentalService WebApiAvailableRentalService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public GetAdditionalDriverChargeController(IWebApiAvailableRentalService WebApiAvailableRentalService)
        {
            if (WebApiAvailableRentalService == null)
            {
                throw new ArgumentNullException("WebApiAvailableRentalService");
            }
            this.WebApiAvailableRentalService = WebApiAvailableRentalService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Available Services with their price
        /// </summary>        
        public IEnumerable<WebApiAdditionalDriver> Post(GetAvailableServicesRequest request)
        {
            return WebApiAvailableRentalService.GetAdditionalDriverWithRates(request.DomainKey, request.TarrifTypeCode);
        }
        #endregion


    }
}