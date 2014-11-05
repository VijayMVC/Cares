using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using DesignationSearchRequestResponse = Cares.Web.Models.DesignationSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Designation Controller
    /// </summary>
    [Authorize]
    public class DesignationController : ApiController
    {
       #region Private
        private readonly IDesignationService designationService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DesignationController(IDesignationService designationService)
        {
            if (designationService == null)
            {
                throw new ArgumentNullException("designationService");
            }
            this.designationService = designationService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Designations
        /// </summary>
        public DesignationSearchRequestResponse Get([FromUri] DesignationSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return designationService.SearchDesignation(request).CreateFrom();
        }

        /// <summary>
        /// Delete Designations 
        /// </summary>
        [ApiException]
        public Boolean Delete(Designation designation)
        {
            if (designation == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            designationService.DeleteDesignation(designation.DesignationId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Designation
        /// </summary>
        [ApiException]
        public Designation Post(Designation designation)
        {
            if (designation == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return designationService.SaveDesignation(designation.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}