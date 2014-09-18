using System;
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
    /// Additional Driver Charge Api Controller
    /// </summary>
    public class AdditionalDriverChargeController : ApiController
    {
        
        #region Private
        private readonly IAdditionalDriverService additionalDriverService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalDriverChargeController(IAdditionalDriverService additionalDriverService)
        {
            if (additionalDriverService == null) throw new ArgumentNullException("additionalDriverService");
            this.additionalDriverService = additionalDriverService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public AdditionalDriverChargeSearchResponse Get([FromUri] AdditionalDriverChargeSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return additionalDriverService.LoadAll(request).CreateFrom();

        }

        ///// <summary>
        ///// Add/Update a Employee
        ///// </summary>
        //[ApiException]
        //public EmployeeListViewContent Post(Employee employee)
        //{
        //    if (employee == null || !ModelState.IsValid)
        //    {
        //        throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
        //    }
        //    EmployeeListViewContent employeeResult = employeeService.SaveEmployee(employee.CreateFrom()).CreateFromListViewContent();
        //    return employeeResult;
        //}

        ///// <summary>
        ///// Delete a Vehicle
        ///// </summary>
        //public void Delete(Employee employee)
        //{
        //    if (employee == null || !ModelState.IsValid)
        //    {
        //        throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
        //    }
        //    employeeService.DeleteEmployee(employeeService.FindById(employee.EmployeeId));
        //}
        
        #endregion
        
    }
}