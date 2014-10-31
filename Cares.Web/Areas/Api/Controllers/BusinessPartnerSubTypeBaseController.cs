using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Business Partner Sub Type Base Controller
    /// </summary>
    [Authorize]
    public class BusinessPartnerSubTypeBaseController : ApiController
    {
        #region Private

        private readonly IBusinessPartnerSubTypeService businessPartnerSubTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerSubTypeBaseController(IBusinessPartnerSubTypeService businessPartnerSubTypeService)
        {
            if (businessPartnerSubTypeService == null)
            {
                throw new ArgumentNullException("businessPartnerSubTypeService");
            }
            this.businessPartnerSubTypeService = businessPartnerSubTypeService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get Business Partner Sub Type Base Data
        /// </summary>
        public Models.BusinessPartnerSubTypeBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return businessPartnerSubTypeService.LoadBusinessPartnerSubTypeBaseData().CreateFrom();
        }
        #endregion
    }
}