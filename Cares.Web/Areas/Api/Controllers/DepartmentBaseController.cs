using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.ResponseModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using DepartmentBaseDataResponse = Cares.Models.ResponseModels.DepartmentBaseDataResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    public class DepartmentBaseController : ApiController
    {
        #region Publuc
        public Models.DepartmentBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

           return departmentService.LoadDepartmentBaseData().CreateFrom();
            
        }
        #endregion


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
    }
}