using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using EmpSearchRequestResponse = Cares.Web.Models.EmpSearchRequestResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Employee Status Controller
    /// </summary>
    [Authorize]
    public class EmployeeStatusController : ApiController
    {
       #region Private
        private readonly IEmpStatusService empStatusService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeStatusController(IEmpStatusService empStatusService)
        {
            if (empStatusService == null)
            {
                throw new ArgumentNullException("empStatusService");
            }
            this.empStatusService = empStatusService;
        }

        #endregion
       #region Public

        /// <summary>
        /// Get Employee Status
        /// </summary>
        public EmpSearchRequestResponse Get([FromUri] EmpSearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return empStatusService.SearchEmployeeStatus(request).CreateFrom();
        }

        /// <summary>
        /// Delete Employee Status 
        /// </summary>
        [ApiException]
        public Boolean Delete(EmpStatus empStatus)
        {
            if (empStatus == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            empStatusService.DeleteEmployeeStatus(empStatus.EmpStatusId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update Employee Status
        /// </summary>
        [ApiException]
        public EmpStatus Post(EmpStatus empStatus)
        {
            if (empStatus == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return empStatusService.SaveEmpStatus(empStatus.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}