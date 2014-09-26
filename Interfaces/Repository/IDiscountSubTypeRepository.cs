using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Discount Sub Type Interface
    /// </summary>
    public interface IDiscountSubTypeRepository : IBaseRepository<DiscountSubType, int>
    {
        /// <summary>
        /// Search Discount Sub Type
        /// </summary>
        IEnumerable<DiscountSubType> SearchDiscountSubType(DiscountSubTypeSearchRequest request, out int rowCount);


        /// <summary>
        /// Duplicate Code Check
        /// </summary>
        bool DoesDiscountSubTypeCodeExist(DiscountSubType discountSubType);

        /// <summary>
        /// Associatoin with discount Type validatoin before the deletion of discount type
        /// </summary>
        bool IsDiscountSubTypeAssociatedWithDiscountType(long discountTypeId);

        /// <summary>
        /// Get Discount Sub Type Details
        /// </summary>
        DiscountSubType GetDiscountSubTypeWithDetails(long discountTypeId);
    }
}
