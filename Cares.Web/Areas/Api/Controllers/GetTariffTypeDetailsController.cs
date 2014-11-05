using System;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Get Tariff Details Api Controller
    /// </summary>
    [Authorize]
    public class GetTariffTypeDetailsController : ApiController
    {
        #region Private
        private readonly ITariffTypeService tariffTypeService;
        #endregion
       
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GetTariffTypeDetailsController(ITariffTypeService tariffTypeService)
        {
            if (tariffTypeService == null)
            {
                throw new ArgumentNullException("tariffTypeService");
            }

            this.tariffTypeService = tariffTypeService;
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
           return tariffTypeService.FindDetailById(id).CreateFrom();
        }

        #endregion

    }
}