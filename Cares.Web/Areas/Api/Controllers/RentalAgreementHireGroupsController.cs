using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
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
        public IEnumerable<HireGroup> Get(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return hireGroupService.GetByCodeAndVehicleInfo(searchText).Select(hg => hg.CreateFrom());
        }

        #endregion
    }
}