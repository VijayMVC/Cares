using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Rental Agreement Hire Groups Api Controller
    /// </summary>
    public class RentalAgreementHireGroupsController : ApiController
    {
        #region Private

        private readonly IHireGroupService hireGroupService;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RentalAgreementHireGroupsController(IHireGroupService hireGroupService)
        {
            if (hireGroupService == null)
            {
                throw new ArgumentNullException("hireGroupService");
            }

            this.hireGroupService = hireGroupService;
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get Hire Groups by Hire Group Code, Vehicle Make / Category / Model / Model Year
        /// </summary>
        public IEnumerable<HireGroupDetailContent> Get([FromUri] GetHireGroupRequest request)
        {
            if (string.IsNullOrEmpty(request.SearchText) || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return hireGroupService.GetByCodeAndVehicleInfo(request.SearchText).Select(hg => hg.CreateFrom());
        }

        #endregion
    }
}