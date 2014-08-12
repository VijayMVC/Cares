using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Base Api Controller
    /// </summary>
    public class RentalAgreementBaseController : ApiController
    {
        #region Private
        
        private readonly IRentalAgreementService rentalAgreementService;
        
        #endregion

        #region Constructors
       
        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementBaseController(IRentalAgreementService rentalAgreementService)
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
        /// Get Base Data
        /// </summary>
        public RentalAgreementBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return rentalAgreementService.GetBaseData().CreateFrom();
        }

        #endregion
    }
}