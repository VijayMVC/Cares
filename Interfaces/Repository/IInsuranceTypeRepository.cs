using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Insurance Type Repository Interface
    /// </summary>
    public interface IInsuranceTypeRepository : IBaseRepository<InsuranceType, long>
    {

        /// <summary>
        /// Search Insurance Type
        /// </summary>
        IEnumerable<InsuranceType> SearchInsuranceType(InsuranceTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// InsuranceType Self code duplication check
        /// </summary>
        bool InsuranceTypeCodeDuplicationCheck(InsuranceType insuranceType);
    }
}
