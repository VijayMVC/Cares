using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{

    /// <summary>
    /// Additional Driver Charge Api Controller
    /// </summary>
    [Authorize]
    public class AdditionalDriverChargeController : ApiController
    {

        #region Private
        private readonly IAdditionalDriverService additionalDriverService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeController(IAdditionalDriverService additionalDriverService)
        {
            if (additionalDriverService == null) throw new ArgumentNullException("additionalDriverService");
            this.additionalDriverService = additionalDriverService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public AdditionalDriverChargeSearchResponse Get([FromUri] AdditionalDriverChargeSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalDriverService.LoadAll(request).CreateFrom();

        }


        /// <summary>
        /// Add/Update a Additional Driver Charge
        /// </summary>
        [ApiException]
        public AdditionalDriverChargeSearchContent Post(AdditionalDriverCharge additionalDriverCharge)
        {
            if (additionalDriverCharge == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            AdditionalDriverChargeSearchContent reponse =
                additionalDriverService.SaveAdditionalDriverCharge(additionalDriverCharge.CreateFrom())
                    .CreateFrom();
            return reponse;

        }

        /// <summary>
        /// Delete a Additional Driver Charge
        /// </summary>
        public void Delete(AdditionalDriverCharge additionalDriverCharge)
        {
            if (additionalDriverCharge == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            additionalDriverService.AdditionalDriverChargeDelete(additionalDriverService.FindById(additionalDriverCharge.AdditionalDriverChargeId));
        }

        #endregion

    }
}