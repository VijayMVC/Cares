using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Seasonal Discount Interface
    /// </summary>
    public interface ISeasonalDiscountService
    {
        /// <summary>
        /// Load Seasonal Discount Base data
        /// </summary>
        SeasonalDiscountBaseResponse GetBaseData();

        /// <summary>
        /// Load Seasonal Discount Main Based on search criteria
        /// </summary>
        /// <returns></returns>
        SeasonalDiscountSearchResponse LoadAll(SeasonalDiscountSearchRequest request);


        /// <summary>
        /// Save Seasonal Discount Main
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        /// <returns></returns>
        SeasonalDiscountMainContent SaveSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain);

        /// <summary>
        /// Delete Seasonal Discount Main
        /// </summary>
        /// <param name="seasonalDiscountMain"></param>
        void DeleteSeasonalDiscount(SeasonalDiscountMain seasonalDiscountMain);

        /// <summary>
        /// Find Seasonal Discount Main By Id
        /// </summary>
        /// <param name="seasonalDiscountMainId"></param>
        /// <returns></returns>
        SeasonalDiscountMain FindById(long seasonalDiscountMainId);

       /// <summary>
        ///  Get Seasonal Discount By Seasonal Discount Main Id
       /// </summary>
       /// <param name="seasonalDiscountMainId"></param>
       /// <returns></returns>
        IEnumerable<SeasonalDiscount> GetSeasonalDiscountsBySeasonalDiscountMainId(long seasonalDiscountMainId);
    }
}
