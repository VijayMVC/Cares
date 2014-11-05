using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using RaMain = Cares.Web.Models.RaMain;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Billing Api Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementBillingController : ApiController
    {
        #region Private

        private readonly IRentalAgreementService rentalAgreementService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBillingController(IRentalAgreementService rentalAgreementService)
        {
            if (rentalAgreementService == null)
            {
                throw new ArgumentNullException("rentalAgreementService");
            }

            this.rentalAgreementService = rentalAgreementService;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Calculates Bill
        /// </summary>
        public RaMain Post(RaMain request)
        {
            if (request == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return rentalAgreementService.GenerateBill(request.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}