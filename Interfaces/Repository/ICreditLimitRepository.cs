using Cares.Models.DomainModels;

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

    }
}