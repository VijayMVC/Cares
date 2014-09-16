using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Department Base Controller
    /// </summary>
    public class DepartmentBaseController : ApiController
    {
        #region Private
        private readonly IDepartmentService departmentService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DepartmentBaseController(IDepartmentService departmentService)
        {
            if (departmentService == null)
            {
                throw new ArgumentNullException("departmentService");
            }
            this.departmentService = departmentService;
        }

        #endregion
        #region Publuc
        /// <summary>
        /// Get Department Base Data
        /// </summary>
        public Models.DepartmentBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return departmentService.LoadDepartmentBaseData().CreateFrom();
        }
        #endregion

    }
}