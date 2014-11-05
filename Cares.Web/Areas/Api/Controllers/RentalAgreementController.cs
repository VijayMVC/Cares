using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using RaMain = Cares.Web.Models.RaMain;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Api Controller
    /// </summary>
    [Authorize]
    public class RentalAgreementController : ApiController
    {
        #region Private

        private readonly IRentalAgreementService rentalAgreementService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementController(IRentalAgreementService rentalAgreementService)
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
        /// Save Rental Agreement
        /// </summary>
        [ApiException]
        public RaMain Get(long id)
        {
            if (id == 0)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            
            return rentalAgreementService.GetById(id).CreateFrom();
        }

        /// <summary>
        /// Save Rental Agreement
        /// </summary>
        [ApiException]
        public RaMain Post(SaveRentalAgreementRequest request)
        {
            if (request == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            request.RaMain.RaStatusId = (short)request.Action;
            return rentalAgreementService.SaveRentalAgreement(request.RaMain.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}