using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;
using Cares.Web.Models;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Seasonal Discount Detail API Controller
    /// </summary>
    public class SeasonalDiscountDetailController : ApiController
    {
         #region Private

        private readonly ISeasonalDiscountService seasonalDiscountService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountDetailController(ISeasonalDiscountService seasonalDiscountService)
        {
            if (seasonalDiscountService == null)
            {
                throw new ArgumentNullException("seasonalDiscountService");
            }
            this.seasonalDiscountService = seasonalDiscountService;
        }

        #endregion

        #region Public
        // GET api/<controller>
        [ValidateFilter]
        public IEnumerable<SeasonalDiscount> Get([FromUri] SeasonalDiscountMain discountMain)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return seasonalDiscountService.GetSeasonalDiscountsBySeasonalDiscountMainId(discountMain.SeasonalDiscountMainId).Select(seasonalDiscount=>seasonalDiscount.CreateFrom());
        }
        #endregion
    }
}