using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Seasonal Discount Main Repository
    /// </summary>
    public interface ISeasonalDiscountMainRepository : IBaseRepository<SeasonalDiscountMain, long>
    {
        /// <summary>
        /// Gety Seasonal Discount Main Based on search criteria
        /// </summary>
        /// <returns></returns>
        SeasonalDiscountSearchResponse GetSeasonalDiscounts(SeasonalDiscountSearchRequest request);

        /// <summary>
        ///Load Seasonal Discount Main By Tariff Type Code 
        /// </summary>
        /// <param name="tariffTypeCode"></param>
        /// <returns></returns>
        IEnumerable<SeasonalDiscountMain> LoadSeasonalDiscountMainByTariffTypeCode(string tariffTypeCode);
    }
}
