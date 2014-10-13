using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Standard Discount Repository Interface
    /// </summary>
    public interface IStandardDiscountRepository : IBaseRepository<StandardDiscount, long>
    {
        /// <summary>
        /// Association check of Standard Discount and vehicle make
        /// </summary>
        bool IsStandardDiscountAssociatedWithVehicleMake(long vehicleMakeId);

        /// <summary>
        /// Association check of Standard Discount and vehicle Category
        /// </summary>
        bool IsStandardDiscountAssociatedWithVehicleCategory(long vehicleCategoryId);

        /// <summary>
        /// Association check of Standard Discount and vehicle Model
        /// </summary>
        bool IsStandardDiscountAssociatedWithVehicleModel(long vehicleModelId);

    }
}
