using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Base Controller
    /// </summary>
    public class BusinessPartnerBaseController : ApiController
    {
        #region Private
        private readonly IBusinessPartnerBaseDataService businessPartnerBaseDataService;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerBaseController(IBusinessPartnerBaseDataService businessPartnerBaseDataService)
        {
            if (businessPartnerBaseDataService == null)
            {
                throw new ArgumentNullException("businessPartnerBaseDataService");
            }
            this.businessPartnerBaseDataService = businessPartnerBaseDataService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Get Business Partner Base Data
        /// </summary>
        public BusinessPartnerBaseResponse Get()
        {
            BusinessPartnerBaseResponse response = businessPartnerBaseDataService.LoadAll().CreateFrom();
            return response;
        }
        #endregion
    }
}