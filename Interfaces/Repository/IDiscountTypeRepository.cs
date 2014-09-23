using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Dicount Type Repository Interface
    /// </summary>
    public interface IDiscountTypeRepository : IBaseRepository<DiscountType, int>
    {
        /// <summary>
        /// Search Discount Type
        /// </summary>
        IEnumerable<DiscountType> SearchDiscountType(DiscountTypeSearchRequest request, out int rowCount);
        
        /// <summary>
        /// Code Duplication Check 
        /// </summary>
        bool DoesDiscountTypeCodeExist(DiscountType discountType);
    }
}
