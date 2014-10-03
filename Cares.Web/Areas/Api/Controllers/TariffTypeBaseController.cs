using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Operation = Cares.Models.DomainModels.Operation;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// tariff Type Base Api Controller
    /// </summary>
    public class TariffTypeBaseController : ApiController
    {
        #region Private
        private readonly ITariffTypeService tariffTypeService;
        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TariffTypeBaseController(ITariffTypeService tariffTypeService)
        {
            if (tariffTypeService == null) throw new ArgumentNullException("tariffTypeService");
            this.tariffTypeService = tariffTypeService;
        }

        #endregion
        #region Public
        // GET api/<controller>
        public TariffTypeBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return tariffTypeService.GetBaseData().CreateFromm();
        }
        #endregion
    }
}