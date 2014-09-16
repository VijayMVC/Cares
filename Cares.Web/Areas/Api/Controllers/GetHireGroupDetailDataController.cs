using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Hire Group Detail Data Api Controller
    /// </summary>
    public class GetHireGroupDetailDataController : ApiController
    {
        #region Private

        private readonly IHireGroupService hireGroupService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetHireGroupDetailDataController(IHireGroupService hireGroupService)
        {
            if (hireGroupService == null)
            {
                throw new ArgumentNullException("hireGroupService");
            }

            this.hireGroupService = hireGroupService;
        }
        #endregion
        #region Public
        // GET api/<controller>/5
        public HireGroupDataDetailResponse Get(long id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return hireGroupService.FindHireGroupId(id).CreateFrom();
            
        }

        #endregion
    }
}