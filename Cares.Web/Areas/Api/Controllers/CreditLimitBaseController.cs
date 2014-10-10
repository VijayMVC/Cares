using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Credit Limit Base Controller
    /// </summary>
    public class CreditLimitBaseController : ApiController
    {
        #region Private
        private readonly ICreditLimitService creditLimitService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CreditLimitBaseController(ICreditLimitService creditLimitService)
        {
            if (creditLimitService == null)
            {
                throw new ArgumentNullException("creditLimitService");
            }
            this.creditLimitService = creditLimitService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Credit Limit Base Data
        /// </summary>
        public Models.CreditLimitBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return creditLimitService.LoadCreditLimitBaseData().CreateFrom();
        }
        #endregion
    }
}