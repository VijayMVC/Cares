using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Tariff Details Api Controller
    /// </summary>
    public class GetTariffDetailsController : ApiController
    {
        #region Private
        private readonly ITarrifTypeService tarrifTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetTariffDetailsController(ITarrifTypeService tarrifTypeService)
        {
            if (tarrifTypeService == null)
            {
                throw new ArgumentNullException("tarrifTypeService");
            }

            this.tarrifTypeService = tarrifTypeService;
        }
        #endregion
        #region Public
        /// <summary>
        /// Get Detail Tariff Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TariffTypeDetailResponse Get(long id)
        {  
           return tarrifTypeService.FindDetailById(id).CreateFrom();
        }

        #endregion

    }
}