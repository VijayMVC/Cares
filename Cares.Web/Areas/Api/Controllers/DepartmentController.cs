using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    public class DepartmentController : ApiController
    {
        #region
        public Models.DepartmentSearchRequestResponse Get([FromUri] DepartmentSearchRequest oppRequest)
        {
            if (oppRequest == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return departmentService.SearchDepartment(oppRequest).CreateFrom();
        }

        public Boolean Delete(Models.Department request)
        {
            if (Request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            departmentService.DeleteDepartment(request.CreateFromm());
            return true;
        }

        public Models.Department Post(Models.Department request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return departmentService.SaveUpdateDepartment(request.CreateFromm()).CreateFromm();
        }   



        #endregion


        #region Constructor
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        #endregion
        #region Private
        private readonly IDepartmentService departmentService;
        #endregion
    }
}