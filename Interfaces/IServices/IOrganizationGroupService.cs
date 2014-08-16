using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    public interface IOrganizationGroupService
    {
        OrgGroupResponse SerchOrgGroup(OrgGroupSearchRequest request);
        void DeleteOrgGroup(OrgGroup request);
        OrgGroup AddUpdateOrgGroup(OrgGroup requestOrgGroup);
    }
}
