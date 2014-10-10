using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Insurance Type API Controller
    /// </summary>
    public class InsuranceTypeController : ApiController
    {  
        #region Private
        /// <summary>
        /// Insurance Type Service 
        /// </summary>
        private readonly IInsuranceTypeService insuranceTypeService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InsuranceTypeController(IInsuranceTypeService insuranceTypeService)
        {
            this.insuranceTypeService = insuranceTypeService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get Insurance Types
        /// </summary>
        public InsuranceTypeSearchRequestResponse Get([FromUri] InsuranceTypeSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  insuranceTypeService.SearchInsuranceType(request).CreateFromm();
        }

        /// <summary>
        /// Delete Insurance Type
        /// </summary>
        [ApiException]
        public Boolean Delete(InsuranceType insuranceType)
        {
            if (insuranceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            insuranceTypeService.DeleteInsuranceType(insuranceType.InsuranceTypeId);
            return true;
        }

        /// <summary>
        /// Add/ Update Insurance Type
        /// </summary>
        [ApiException]
        public InsuranceType Post(InsuranceType insuranceType)
        {
            if (insuranceType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return insuranceTypeService.AddUpdateInsuranceType(insuranceType.CreateFromm()).CreateFromm();
        }
        #endregion
    }
} 