using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Interfaces.IServices;
using Models.RequestModels;
using Models.ResponseModels;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type API Controller
    /// </summary>
    public class TarrifTypeController : ApiController
    {
        #region Private
        private readonly ITarrifTypeService tarrifTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeController(ITarrifTypeService tarrifTypeService)
        {
            if (tarrifTypeService == null)
            {
                throw new ArgumentNullException("tarrifTypeService");
            }

            this.tarrifTypeService = tarrifTypeService;
        }
        #endregion
        #region Public
        // GET api/<controller>
        public TarrifTypeResponse Get(TarrifTypeRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tarrifTypeService.LoadTarrifTypes((request));
        }
        #endregion

    }
}