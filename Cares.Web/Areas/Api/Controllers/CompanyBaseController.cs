using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using CompanyBaseDataResponse = Cares.Web.Models.CompanyBaseDataResponse;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Company base Controller
    /// </summary>
    public class CompanyBaseController : ApiController
    {
        #region Private

        private readonly ICompanyService companyService;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyBaseController(ICompanyService companyService)
        {
            if (companyService == null)
            {
                throw new ArgumentNullException("companyService");
            }
            this.companyService = companyService;
        }

        #endregion
        #region Public
        /// <summary>
        /// Get  Company base data
        /// </summary>
        public CompanyBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return companyService.LoadCompanyBaseData().CreateFrom();
        }
        #endregion

    }
}