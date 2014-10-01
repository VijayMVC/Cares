using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Legal Status Repository Interface
    /// </summary>
    public interface IBusinessLegalStatusRepository : IBaseRepository<BusinessLegalStatus, long>
    {
        /// <summary>
        /// Search Business Legal Status
        /// </summary>
        IEnumerable<BusinessLegalStatus> SearchBusinessLegalStatus(BusinessLegalStatusSearchRequest request, out int rowCount);

        /// <summary>
        /// Self-code duplication check
        /// </summary>
        bool BusinessLegalStatusCodeDuplicationCheck(BusinessLegalStatus request);
    }
}
