using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Web.ModelMappers;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Seasonal Discount Base API Controller
    /// </summary>
    [Authorize]
    public class SeasonalDiscountBaseController : ApiController
    {
        #region Private

        private readonly ISeasonalDiscountService seasonalDiscountService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountBaseController(ISeasonalDiscountService seasonalDiscountService)
        {
            if (seasonalDiscountService == null)
            {
                throw new ArgumentNullException("seasonalDiscountService");
            }
            this.seasonalDiscountService = seasonalDiscountService;
        }

        #endregion

        #region Public
        /// <summary>
        /// Get Seasonal Discount Base Data
        /// </summary>
        public Models.SeasonalDiscountBaseResponse Get()
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return seasonalDiscountService.GetBaseData().CreateFrom();
        }
        #endregion
    }
}