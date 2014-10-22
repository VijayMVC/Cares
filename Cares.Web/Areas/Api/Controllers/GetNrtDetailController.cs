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
    /// Get Nrt Detail API Controller
    /// </summary>
    public class GetNrtDetailController : ApiController
    {
        #region Private

        private readonly INRTService nrtService;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetNrtDetailController(INRTService nrtService)
        {
            if (nrtService == null && !ModelState.IsValid)
            {
                throw new ArgumentNullException("nrtService");
            }

            this.nrtService = nrtService;
        }
        #endregion

        #region Public
        /// <summary>
        ///  Get NRT by Id
        /// </summary>
        /// <returns></returns>
        public NrtMain Get(long id)
        {
            if (id == 0)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return nrtService.FindById(id).CreateFrom();
        }

        #endregion

    }
}