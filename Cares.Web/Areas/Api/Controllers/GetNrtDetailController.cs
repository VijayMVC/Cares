using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public NrtMain Post([FromUri]NrtMain nrtMain)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
           //nrtService.FindById(nrtMain.NrtMainId);
           return nrtService.FindById(7).CreateFrom();
            
        }

        #endregion

    }
}