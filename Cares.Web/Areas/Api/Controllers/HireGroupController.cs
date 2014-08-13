using System;
using System.Collections.Generic;
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
    /// Hire Group Api Controller
    /// </summary>
    public class HireGroupController : ApiController
    {
        #region Private
        private readonly IHireGroupService hireGroupService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupController(IHireGroupService hireGroupService)
        {
            if (hireGroupService == null)
            {
                throw new ArgumentNullException("hireGroupService");
            }

            this.hireGroupService = hireGroupService;
        }
        #endregion
        #region Public
        // GET api controller
        public HireGroupSearchResponse Get([FromUri] HireGroupSearchRequest request)
        {
            return hireGroupService.LoadHireGroups((request)).CreateFrom();
        }
        /// <summary>
        /// Add a Hire Group
        /// </summary>
        public void Put(HireGroup hireGroup)
        {

            if (hireGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            hireGroupService.AddHireGroup(hireGroup.CreateFrom());
        }
        /// <summary>
        /// Update a Hire Group
        /// </summary>
        public void Post(HireGroup hireGroup)
        {
            if (hireGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            hireGroupService.UpdateHireGroup(hireGroup.CreateFrom());
        }
        /// <summary>
        /// Delete a Hire Group
        /// </summary>
        public void Delete(HireGroup hireGroup)
        {
            if (hireGroup == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            hireGroupService.DeleteHireGroup(hireGroupService.FindById(hireGroup.HireGroupId));
        }
        #endregion
    }
}