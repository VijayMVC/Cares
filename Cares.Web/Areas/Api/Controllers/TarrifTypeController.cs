using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
using DomainModels = Models.RequestModels;
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
        public TarrifTypeResponse Get([FromUri] DomainModels.TarrifTypeRequest request)
        {
            return tarrifTypeService.LoadTarrifTypes((request)).CreateFrom();
        }
        /// <summary>
        /// Update a Tarrif Type
        /// </summary>
        public void Post(TariffTypeDetail tarrifType)
        {
            if (tarrifType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            tarrifTypeService.UpdateTarrifType(tarrifType.CreateFrom());
        }
        /// <summary>
        /// Add a Tarrif Type
        /// </summary>
        public TariffTypeDetail Put(TariffTypeDetail tarrifType)
        {
            if (tarrifType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tarrifTypeService.AddTarrifType(tarrifType.CreateFrom()).CreateFromDetail();

        }
        #endregion

    }
}