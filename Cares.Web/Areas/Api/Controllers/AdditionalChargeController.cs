using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Additional Charge Api Controller
    /// </summary>
    public class AdditionalChargeController : ApiController
    {

        #region Private
        private readonly IAdditionalChargeService additionalChargeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeController(IAdditionalChargeService additionalChargeService)
        {
            if (additionalChargeService == null) throw new ArgumentNullException("additionalChargeService");
            this.additionalChargeService = additionalChargeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public Models.AdditionalChargeSearchResponse Get([FromUri] AdditionalChargeSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalChargeService.LoadAll(request).CreateFrom();

        }


        /// <summary>
        /// Add/Update a Additional Driver Charge
        /// </summary>
        [ApiException]
        public Models.AdditionalChargeType Post(Models.AdditionalChargeType additionalChargeType)
        {
            if (additionalChargeType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            Models.AdditionalChargeType reponse =
                additionalChargeService.SaveAdditionalCharge(additionalChargeType.CreateFrom())
                    .CreateFrom();
            return reponse;
        }

        /// <summary>
        /// Delete a AdditionalCharge
        /// </summary>
        public void Delete(AdditionalChargeType additionalChargeType)
        {
            if (additionalChargeType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            additionalChargeService.DeleteAdditionalCharge(additionalChargeService.FindById(additionalChargeType.AdditionalChargeTypeId));

        }

        #endregion
    }
}