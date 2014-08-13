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
    /// tariff Type Api Controller
    /// </summary>
    public class TariffTypeController : ApiController
    {
        #region Private
        private readonly ITariffTypeService tariffTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeController(ITariffTypeService tariffTypeService)
        {
            if (tariffTypeService == null)
            {
                throw new ArgumentNullException("tariffTypeService");
            }

            this.tariffTypeService = tariffTypeService;
        }
        #endregion
        #region Public
        // GET api/<controller>
        public TariffTypeSearchResponse Get([FromUri] TariffTypeRequest request)
        {
           return tariffTypeService.LoadtariffTypes((request)).CreateFrom();
        }
        /// <summary>
        /// Update a tariff Type
        /// </summary>
        public TariffType Post(TariffTypeDetail tariffType)
        {
            if (tariffType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }

            return tariffTypeService.UpdatetariffType(tariffType.CreateFrom()).CreateFrom();
        }
        /// <summary>
        /// Add a tariff Type
        /// </summary>
        public TariffType Put(TariffTypeDetail tariffType)
        {
            if (tariffType == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffTypeService.AddtariffType(tariffType.CreateFrom()).CreateFrom();

        }
        #endregion

    }
}