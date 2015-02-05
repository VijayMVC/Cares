using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Department Controller 
    /// </summary>
    [Authorize]
    public class DepartmentController : ApiController
    {
        #region Private
        /// <summary>
        /// Private 
        /// </summary>
        private readonly IDepartmentService departmentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Department Constructor
        /// </summary>>
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        #endregion
        #region public
        /// <summary>
        /// Get Departments
        /// </summary>
        public Models.DepartmentSearchRequestResponse Get([FromUri] DepartmentSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return departmentService.SearchDepartment(oppRequest).CreateFrom();
        }
        /// <summary>
        /// Delete Departments
        /// </summary>
        [ApiException]
        [HttpDelete]
        public Boolean Delete(Models.Department request)
        {
            if (Request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            departmentService.DeleteDepartment(request.DepartmentId);
            return true;
        }
        /// <summary>
        /// Add/Update Department
        /// </summary>
        [ApiException]
        public Models.Department Post(Models.Department request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return departmentService.SaveUpdateDepartment(request.CreateFromm()).CreateFromm();
        }   
        #endregion   
    }
}