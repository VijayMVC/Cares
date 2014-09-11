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
    /// Employee Detail Api Controller
    /// </summary>
    public class EmployeeDetailController : ApiController
    {
         #region Private

        private readonly IEmployeeService employeeService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeDetailController(IEmployeeService employeeService)
        {
            if (employeeService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("employeeService");
            }

            this.employeeService = employeeService;
        }
        #endregion

        #region Public
        /// <summary>
        /// Vehicle Detail
        /// </summary>
        /// <returns></returns>
        public Employee Get([FromUri]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return employeeService.GetEmployeeDetail(employee.EmployeeId).CreateFromEmployeeDetail();
        }

        #endregion
       
    }
}