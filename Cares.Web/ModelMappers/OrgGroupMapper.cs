using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class OrgGroupMapper
    {

        public static ApiModel.OrgGroupRequestResponse CreateFrom(this OrgGroupResponse source)
        {
            return new ApiModel.OrgGroupRequestResponse
            {
                OrgGroups = source.OrgGroups.Select(orgGroup => orgGroup.CreateFromResponse()),
                TotalCount = source.TotalCount
            };
        }
        public static ApiModel.OrgGroup CreateFromResponse(this OrgGroup source)
        {
            return new ApiModel.OrgGroup
            {
                OrgGroupId = source.OrgGroupId,
                OrgGroupCode = source.OrgGroupCode,
                OrgGroupName = source.OrgGroupName,
                OrgGroupDescription = source.OrgGroupDescription
            };
        }

        public static OrgGroup CreateFromClientToServer(this ApiModel.OrgGroup orgGroup)
        {
            return new OrgGroup
            {
                  OrgGroupId = orgGroup.OrgGroupId,
                  OrgGroupCode = orgGroup.OrgGroupCode,
                  OrgGroupName = orgGroup.OrgGroupName,
                  OrgGroupDescription = orgGroup.OrgGroupDescription
            };
        }
        public static ApiModel.OrgGroupDropDown CreateFrom(this OrgGroup source)
        {
            return new ApiModel.OrgGroupDropDown
            {
               OrgGroupId = source.OrgGroupId,
               OrgGroupCode = source.OrgGroupCode,
               OrgGroupName = source.OrgGroupName
            };
        }
    }
}
