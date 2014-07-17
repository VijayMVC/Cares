using System;
using System.Web.Http;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Interfaces.IServices;
namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Tarrif Type Base Api Controller
    /// </summary>
    public class TarrifTypeBaseController : ApiController
    {
        private readonly ITarrifTypeService tarrifTypeService;

        #region Private

        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public TarrifTypeBaseController(ITarrifTypeService tarrifTypeService)
        {
            if (tarrifTypeService == null) throw new ArgumentNullException("tarrifTypeService");
            this.tarrifTypeService = tarrifTypeService;
        }

        #endregion
        #region Public
        // GET api/<controller>
        public TarrifTypeBaseResponse Get()
        {
            return tarrifTypeService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}