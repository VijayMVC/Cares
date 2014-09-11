using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Employee Api Contoller
    /// </summary>
    public class EmployeeController : ApiController
    {
        #region Private
        private readonly IEmployeeService employeeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeController(IEmployeeService employeeService)
        {
            if (employeeService == null) throw new ArgumentNullException("employeeService");
            this.employeeService = employeeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public Models.EmployeeSearchResponse Get([FromUri] EmployeeSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return employeeService.LoadAll(request).CreateFrom();

        }

        /// <summary>
        /// Add/Update a Employee
        /// </summary>
        [ApiException]
        public EmployeeListViewContent Post(Employee employee)
        {
            if (employee == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            EmployeeListViewContent employeeResult = employeeService.SaveEmployee(employee.CreateFrom()).CreateFromListViewContent();
            return employeeResult;
        }
        #endregion

    }
}