using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.DomainModels;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Additional Charge Detail Api Controller
    /// </summary>
    public class AdditionalChargeDetailController : ApiController
    {
      #region Private

        private readonly IAdditionalChargeService additionalChargeService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeDetailController(IAdditionalChargeService additionalChargeService)
        {
            if (additionalChargeService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("additionalChargeService");
            }

            this.additionalChargeService = additionalChargeService;
        }
        #endregion

        #region Public
        /// <summary>
        ///  Additional Driver Charge Detail
        /// </summary>
        /// <returns></returns>
        public List<Models.AdditionalCharge> Get([FromUri]AdditionalChargeType additionalChargeType)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            List<AdditionalCharge> result =
                additionalChargeService.GetAdditionalChargesByAdditionChargeTypeId(additionalChargeType.AdditionalChargeTypeId).ToList();
            return result.Count>0?result.Select(x => x.CreateFrom()).ToList():null;
        }

        #endregion
    }
}