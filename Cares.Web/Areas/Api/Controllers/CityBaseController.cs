using Cares.Interfaces.IServices;
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// City Base Controller
    /// </summary>
    public class CityBaseController : ApiController
    {
        #region Private
        private readonly ICityService cityService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityBaseController(ICityService cityService)
        {
            if (cityService == null)
            {
                throw new ArgumentNullException("cityService");
            }
            this.cityService = cityService;
        }

        #endregion
        #region Public

        /// <summary>
        /// Get City Base Data
        /// </summary>
        public Models.CityBaseDataResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return cityService.LoadCityBaseData().CreateFrom();
        }
        #endregion

    }
}