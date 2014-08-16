using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    public interface IOrganizationGroupRepository:IBaseRepository<OrgGroup, long>
    {
        IEnumerable<OrgGroup> SearchOrgGroup(OrgGroupSearchRequest request, out int rowCount);
    }
}
