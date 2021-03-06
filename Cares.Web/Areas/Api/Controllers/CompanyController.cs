﻿using System;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Company API Controller
    /// </summary>
    public class CompanyController : ApiController
    {  
        #region Private
        /// <summary>
        /// Company Service 
        /// </summary>
        private readonly ICompanyService companyService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyController(ICompanyService iCompanyService)
        {
            companyService = iCompanyService;
        }
        #endregion
        #region public

        /// <summary>
        /// Get compnies
        /// </summary>
        public CompanySearchRequestResponse Get([FromUri] CompanySearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int) HttpStatusCode.BadRequest, "Invalid Request");
            }
            return  companyService.SearchCompany(request).CreateFrom();
        }

        /// <summary>
        /// Delete Company
        /// </summary>
        [ApiException]
        public Boolean Delete(Company request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            companyService.DeleteCompany(request.CompanyId);
            return true;
        }

        /// <summary>
        /// Add/ Update Company
        /// </summary>
        [ApiException]
        public Company Post(Company request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
          return companyService.AddUpdateCompany(request.CreateFrom()).CreateFromm();
        }
        #endregion
    }
} 