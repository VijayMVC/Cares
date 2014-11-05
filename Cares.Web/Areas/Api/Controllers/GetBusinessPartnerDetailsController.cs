using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Tariff Details Api Controller
    /// </summary>
    [Authorize]
    public class GetBusinessPartnerDetailsController : ApiController
    {
        #region Private
        private readonly IBusinessPartnerService businessPartnerService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetBusinessPartnerDetailsController(IBusinessPartnerService businessPartnerService)
        {
            if (businessPartnerService == null)
            {
                throw new ArgumentNullException("businessPartnerService");
            }

            this.businessPartnerService = businessPartnerService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Business Partner Detail By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerDetail Get(long id)
        {
            return businessPartnerService.FindBusinessPartnerById(id).CreateApiDetailFromDomainModel();
        }

        #endregion

    }
}