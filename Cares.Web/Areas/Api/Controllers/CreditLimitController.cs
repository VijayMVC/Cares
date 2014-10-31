using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Credit Limit Controller
    /// </summary>
    [Authorize]
    public class CreditLimitController : ApiController
    {
       #region Private
        private readonly ICreditLimitService creditLimitService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CreditLimitController(ICreditLimitService creditLimitService)
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
        /// Get Credit Limits
        /// </summary>
        public CreditLimitSearchRequestResponse Get([FromUri] CreditLimitSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return creditLimitService.SearchCreditLimit(request).CreateFrom();
        }

        /// <summary>
        /// Delete Credit Limit 
        /// </summary>
        [ApiException]
        public Boolean Delete(CreditLimit creditLimit)
        {
            if (creditLimit == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            creditLimitService.DeleteCreditLimit(creditLimit.CreditLimitId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Credit Limit
        /// </summary>
        [ApiException]
        public CreditLimit Post(CreditLimit creditLimit)
        {
            if (creditLimit == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return creditLimitService.AddUpdateCreditLimit(creditLimit.CreateFrom()).CreateFrom();
        }

        #endregion
    }
}