using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Seasonal Discount Repository Interface
    /// </summary>
    public interface ISeasonalDiscountRepository : IBaseRepository<SeasonalDiscount, long>
    {
        /// <summary>
        /// Get Seasonal Discounts By Seasonal Discount Main Id
        /// </summary>
        /// <param name="seasonalDiscountMainId"></param>
        /// <returns></returns>
        IEnumerable<SeasonalDiscount> GetSeasonalDiscountsBySeasonalDiscountMainId(long seasonalDiscountMainId);

        /// <summary>
        /// Association check of Seasonal Discount and Vehicle Make
        /// </summary>
        bool IsSeasonalDiscountAssociatedWithVehicleMake(long vehicleMakeId);

        /// <summary>
        /// Association check of Seasonal Discount and Vehicle Category
        /// </summary>
        bool IsSeasonalDiscountAssociatedWithVehicleCategory(long vehicleCategoryId);

    }
}
