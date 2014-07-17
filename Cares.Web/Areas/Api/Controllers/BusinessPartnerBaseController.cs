using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using Models.ResponseModels;

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
        /// Get Base Data
        /// </summary>
        public BusinessPartnerBaseDataResponse Get()
        {
            BusinessPartnerBaseDataResponse response = businessPartnerBaseDataService.LoadAll();
            return response;
        }
        #endregion
    }
}