using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Credit Limit Service Interface
    /// </summary>
    public interface ICreditLimitService
    {
        /// <summary>
        /// Load all Credit Limits
        /// </summary>
        IEnumerable<CreditLimit> LoadAll();

        /// <summary>
        /// Delete Credit Limit
        /// </summary>
        void DeleteCreditLimit(long creditLimitid);

        /// <summary>
        /// Load Base data of Credit Limit
        /// </summary>
        CreditLimitBaseDataResponse LoadCreditLimitBaseData();

        /// <summary>
        /// Search Credit Limit
        /// </summary>
        CreditLimitSearchRequestResponse SearchCreditLimit(CreditLimitSearchRequest request);

        /// <summary>
        /// Add / Update Credit Limit
        /// </summary>
        CreditLimit AddUpdateCreditLimit(CreditLimit creditLimit);
    }
}
