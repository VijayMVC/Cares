using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type Api Controller
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
        public TarrifTypeSearchResponse Get([FromUri] TarrifTypeRequest request)
        {
           return tarrifTypeService.LoadTarrifTypes((request)).CreateFrom();
        }
        /// <summary>
        /// Update a Tarrif Type
        /// </summary>
        public TarrifType Post(TariffTypeDetail tarrifType)
        {
            if (tarrifType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tarrifTypeService.UpdateTarrifType(tarrifType.CreateFrom()).CreateFrom();
        }
        /// <summary>
        /// Add a Tarrif Type
        /// </summary>
        public TarrifType Put(TariffTypeDetail tarrifType)
        {
            if (tarrifType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tarrifTypeService.AddTarrifType(tarrifType.CreateFrom()).CreateFrom();

        }
        #endregion

    }
}