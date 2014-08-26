using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    ///  Organization Group Repository Interface
    /// </summary>
    public interface IOrganizationGroupRepository:IBaseRepository<OrgGroup, long>
    {
        /// <summary>
        /// Search  Organization Group
        /// </summary>
        IEnumerable<OrgGroup> SearchOrgGroup(OrgGroupSearchRequest request, out int rowCount);
        /// <summary>
        ///  Organization Group Code validation 
        /// </summary>
        bool IsOrgGroupCodeExists(OrgGroup orgGroup);
    }
}
