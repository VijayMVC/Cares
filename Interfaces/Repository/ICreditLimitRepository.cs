using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Credit Limit Repository Interface
    /// </summary>
    public interface ICreditLimitRepository : IBaseRepository<CreditLimit, long>
    {
        /// <summary>
        /// Associatin check of cradit limit with rating type
        /// </summary>
        bool IsRatingTypeAssociatedWithCreditLimit(long ratingTypeId);

        /// <summary>
        /// Association check of Business Partner Sub Type and credit limit
        /// </summary>
        bool IsBusinessPartnerSubTypeAssociatedWithCreditLimit(long businessPartnerSubTypeId);

        /// <summary>
        /// Search Credit Limit
        /// </summary>
        IEnumerable<CreditLimit> SearchCreditLimit(CreditLimitSearchRequest request, out int rowCount);

        /// <summary>
        /// Get detail object of Credit Limit
        /// </summary>
        CreditLimit GetCreditLimitWithDetail(long creditLimitId);

       
    }
}