using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Service Type Repository Interface
    /// </summary>
    public interface IServiceTypeRepository:  IBaseRepository<ServiceType, long>
    {
        /// <summary>
        /// Search Service Type
        /// </summary>
        IEnumerable<ServiceType> SearchServiceType(ServiceTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// Code duplication check
        /// </summary>
        bool ServiceTypeCodeDuplicationCheck(ServiceType serviceType);
    }
}
