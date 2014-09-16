using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Employee Base Api Controller
    /// </summary>
    public class EmployeeBaseController : ApiController
    {
        #region Private
        private readonly IEmployeeService employeeService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeBaseController(IEmployeeService employeeService)
        {
            if (employeeService == null) throw new ArgumentNullException("employeeService");
            this.employeeService = employeeService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public Models.EmployeeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return employeeService.GetBaseData().CreateFrom();
        }
        #endregion

    }
}