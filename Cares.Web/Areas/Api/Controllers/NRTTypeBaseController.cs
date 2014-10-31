using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Nrt Type base Controller
    /// </summary>
    [Authorize]
    public class NrtTypeBaseController : ApiController
    {
        #region Private

        private readonly INrtTypeService nrtTypeService;

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtTypeBaseController(INrtTypeService nrtTypeService)
        {
            if (nrtTypeService == null)
            {
                throw new ArgumentNullException("nrtTypeService");
            }
            this.nrtTypeService = nrtTypeService;
        }

        #endregion
        #region Public
        /// <summary>
        /// Get NrtType base data
        /// </summary>
        public NrtTypeBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return nrtTypeService.LoadNrtTypeBaseData().CreateFrom();
        }
        #endregion

    }
}