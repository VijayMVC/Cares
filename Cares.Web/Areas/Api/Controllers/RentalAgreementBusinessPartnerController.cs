using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Business Partner Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementBusinessPartnerController : ApiController
    {
        #region Private
        
        private readonly IBusinessPartnerService businessPartnerService;
        
        #endregion
        
        #region Constructors
        
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBusinessPartnerController(IBusinessPartnerService businessPartnerService)
        {
            if (businessPartnerService == null)
            {
                throw new ArgumentNullException("businessPartnerService");
            }

            this.businessPartnerService = businessPartnerService;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get Business Partner For Rental Agreement
        /// </summary>
        public BusinessPartnerDetail Get([FromUri] GetBusinessPartnerRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return businessPartnerService.GetForRentalAgreement(request).CreateFromForRa();
        }

        #endregion

    }
}