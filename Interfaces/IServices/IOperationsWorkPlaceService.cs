
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Operations Work Place service interfce
    /// </summary>
    public interface IOperationsWorkPlaceService
    {
        /// <summary>
        /// Get Operations Work Place By Workplace Ido
        /// </summary>
        OperationWorkplaceSearchByIdResponse GetOperationsWorkPlaceByWorkplaceId(long workplaceId);

        /// <summary>
        /// Get Operation Workplace by domainkey
        /// </summary>
        IEnumerable<OperationsWorkPlace> GetOperationsWorkPlacesByDomainKey(long domainKey);
    }
}
