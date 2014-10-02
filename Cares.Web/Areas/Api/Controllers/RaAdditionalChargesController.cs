using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Ra Additional Charge Api Controller
    /// </summary>
    public class RaAdditionalChargeController : ApiController
    {

        #region Private
        private readonly IAdditionalChargeService additionalChargeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RaAdditionalChargeController(IAdditionalChargeService additionalChargeService)
        {
            if (additionalChargeService == null) throw new ArgumentNullException("additionalChargeService");
            this.additionalChargeService = additionalChargeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public IEnumerable<Models.AdditionalCharge> Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalChargeService.GetAllForRa().Select(ac => ac.CreateFrom());

        }
        
        #endregion
    }
}