using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using System.Web;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Region Controller Class
    /// </summary>
    public class RegionsController : ApiController
    {
        #region Private
        private readonly ICountryRegionsService countryRegionsService;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionsController(ICountryRegionsService countryRegionsservice)
        {
            if (countryRegionsservice == null)
            {
                throw new ArgumentNullException("countryRegionsservice");
            }
            this.countryRegionsService = countryRegionsservice;
        }

        #endregion
        #region Public
        // GET api/<controller>
        public IEnumerable<RegionDropDown> Get(int countryId)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            var abc = countryRegionsService.GetCoutryRegion(countryId);
            IEnumerable<RegionDropDown> abcd = abc.Select(x => x.CreateFrom());
            return abcd;
        }
        #endregion
    }
}