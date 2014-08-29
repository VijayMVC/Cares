using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    ///  Organization Group Mapper
    /// </summary>
    public static class OrgGroupMapper
    {
        /// <summary>
        /// Create From Response Model to web 
        /// </summary>
        public static ApiModel.OrgGroupRequestResponse CreateFrom(this OrgGroupResponse source)
        {
            return new ApiModel.OrgGroupRequestResponse
            {
                OrgGroups = source.OrgGroups.Select(orgGroup => orgGroup.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
        public static ApiModel.OrgGroup CreateFromm(this OrgGroup source)
        {
            return new ApiModel.OrgGroup
            {
                OrgGroupId = source.OrgGroupId,
                OrgGroupCode = source.OrgGroupCode,
                OrgGroupName = source.OrgGroupName,
                OrgGroupDescription = source.OrgGroupDescription
            };
        }

        /// <summary>
        /// Create From web model
        /// </summary>
        public static OrgGroup CreateFrom(this ApiModel.OrgGroup orgGroup)
        {
            return new OrgGroup
            {
                  OrgGroupId = orgGroup.OrgGroupId,
                  OrgGroupCode = orgGroup.OrgGroupCode,
                  OrgGroupName = orgGroup.OrgGroupName,
                  OrgGroupDescription = orgGroup.OrgGroupDescription
            };
        }

        /// <summary>
        /// Create From Domain Model
        /// </summary>
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
