using System;
using System.Net;
using System.Web;
using System.Web.Http;
using Cares.Interfaces.IServices;
using Cares.Models.RequestModels;
using Cares.Web.ModelMappers;
using Cares.WebBase.Mvc;

namespace Cares.Web.Areas.Api.Controllers
{
    /// <summary>
    /// Seasonal Discount API Controller
    /// </summary>
    [Authorize]
    public class SeasonalDiscountController : ApiController
    {
        #region Private

        private readonly ISeasonalDiscountService seasonalDiscountService;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SeasonalDiscountController(ISeasonalDiscountService seasonalDiscountService)
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
        public Models.SeasonalDiscountSearchResponse Get([FromUri] SeasonalDiscountSearchRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            return seasonalDiscountService.LoadAll(request).CreateFrom();

        }


        /// <summary>
        /// Add/Update a Seasonal Discount Main
        /// </summary>
        [ApiException]
        public Models.SeasonalDiscountMainContent Post(Models.SeasonalDiscountMain seasonalDiscountMain)
        {
            if (seasonalDiscountMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            Models.SeasonalDiscountMainContent reponse =
                seasonalDiscountService.SaveSeasonalDiscount(seasonalDiscountMain.CreateFrom())
                    .CreateFrom();
            return reponse;

        }

        /// <summary>
        /// Delete a Seasonal Discount
        /// </summary>
        public void Delete(Models.SeasonalDiscountMain seasonalDiscountMain)
        {
            if (seasonalDiscountMain == null || !ModelState.IsValid)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Invalid Request");
            }
            seasonalDiscountService.DeleteSeasonalDiscount(seasonalDiscountService.FindById(seasonalDiscountMain.SeasonalDiscountMainId));
        }

        #endregion
    }
}