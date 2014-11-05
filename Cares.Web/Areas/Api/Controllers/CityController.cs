using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;
using System;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// City Controller
    /// </summary>
    [Authorize]
    public class CityController : ApiController
    {
       #region Private
        private readonly ICityService cityService;
        #endregion
       #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CityController(ICityService cityService)
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
        /// Get Cities
        /// </summary>
        public Models.CitySearchRequestResponse Get([FromUri] CitySearchRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return cityService.SearchCity(request).CreateFrom();
        }

        /// <summary>
        /// Delete City 
        /// </summary>
        [ApiException]
        public Boolean Delete(City city)
        {
            if (city == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            cityService.DeleteCity(city.CityId);
            return true;
        }

        /// <summary>
        ///  ADD/ Update City
        /// </summary>
        [ApiException]
        public City Post(City city)
        {
            if (city == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return cityService.SaveCity(city.CreateFrom()).CreateFromm();
        }

        #endregion
    }
}