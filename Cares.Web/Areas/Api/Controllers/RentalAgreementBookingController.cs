using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;
using RaMain = Cares.Web.Models.RaMain;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Booking Api Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementBookingController : ApiController
    {
        #region Private

        private readonly IRentalAgreementService rentalAgreementService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBookingController(IRentalAgreementService rentalAgreementService)
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
        /// Get Rental Agreement By Booking Main
        /// </summary>
        [ApiException]
        public RaMain Get(long id)
        {
            if (id == 0)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            
            return rentalAgreementService.GetByBooking(id).CreateFrom();
        }
        
        #endregion
    }
}