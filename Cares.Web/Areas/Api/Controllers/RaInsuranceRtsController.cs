using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Ra Insurance Rts Api Controller
    /// </summary>
    public class RaInsuranceRtsController : ApiController
    {

        #region Private
        private readonly IInsuranceTypeService insuranceRateService;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public RaInsuranceRtsController(IInsuranceTypeService insuranceRateService)
        {
            if (insuranceRateService == null) throw new ArgumentNullException("insuranceRateService");
            this.insuranceRateService = insuranceRateService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public IEnumerable<Models.InsuranceRtDetailContent> Get()
        {
            return insuranceRateService.GetAllForRa().Select(ac => ac.CreateFrom());

        }
        
        #endregion
    }
}