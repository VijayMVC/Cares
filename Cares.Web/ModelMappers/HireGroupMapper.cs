using System.Linq;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
using ResponseModel = Cares.Models.ResponseModels;
using RequestModel = Cares.Models.RequestModels;
namespace Cares.Web.ModelMappers
{
    public static class HireGroupMapper
    {
        #region For Tariff Rate
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static HireGroup CreateFromForTariffRate(this DomainModels.HireGroup source)
        {
            return new HireGroup
            {
                HireGroupId = source.HireGroupId,
                HireGroupName = source.HireGroupCode + "-" + source.HireGroupName,
            };
        }
        #endregion
        #region Hire Group
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static HireGroup CreateFrom(this DomainModels.HireGroup source)
        {
            return new HireGroup
            {
                HireGroupId = source.HireGroupId,
                HireGroupName = source.HireGroupName,
                HireGroupCode = source.HireGroupCode,
                Description = source.HireGroupDescription,
                IsParent = source.IsParent,
                ParentHireGroupName = source.ParentHireGroup != null ? source.ParentHireGroup.HireGroupCode + '-' + source.ParentHireGroup.HireGroupName : string.Empty,
                ParentHireGroupId = source.ParentHireGroup != null ? source.ParentHireGroup.HireGroupId : 0,
                CompanyName = source.Company.CompanyCode + '-' + source.Company.CompanyName,
                CompanyId = source.Company.CompanyId,
            };
        }
        public static ParentHireGroup CreateFromParentHireGroup(this DomainModels.HireGroup source)
        {
            return new ParentHireGroup
            {
                ParentHireGroupId = source.HireGroupId,
                ParentHireGroupName = source.HireGroupCode + '-' + source.HireGroupName,
                CompanyId = source.CompanyId
            };
        }
        /// <summary>
        /// Create Hire Group Search Response from domain Hire Group Search Response
        /// </summary>
        public static HireGroupSearchResponse CreateFrom(this ResponseModel.HireGroupSearchResponse source)
        {
            return new HireGroupSearchResponse
            {
                HireGroups = source.HireGroups.Select(hg => hg.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create Hire Group Search Response from domain Hire Group Search Response
        /// </summary>
        public static HireGroupBaseResponse CreateFrom(this ResponseModel.HireGroupBaseResponse source)
        {
            return new HireGroupBaseResponse
            {
                ParentHireGroups = source.ParentHireGroups.Select(hg => hg.CreateFromParentHireGroup()),
                Companies = source.Companies.Select(company => company.CreateFrom()),
                VehicleCategories = source.VehicleCategories.Select(category => category.CreateFrom()),
                VehicleModels = source.VehicleModels.Select(model => model.CreateFrom()),
                VehicleMakes = source.VehicleMakes.Select(makes => makes.CreateFrom()),

            };
        }

        public static DomainModels.HireGroupDetail CreateFromForHireGroupAdd(this HireGroupDetailForHireGroup source)
        {
            return new DomainModels.HireGroupDetail
            {
                HireGroupDetailId = source.HireGroupDetailId,
                VehicleMakeId = source.VehicleMakeId,
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleModelId = source.VehicleModelId,
                ModelYear = source.VehicleModelYear,

            };
        }
        public static DomainModels.HireGroup CreateFromAdd(this HireGroup source)
        {
            return new DomainModels.HireGroup
            {
                HireGroupId = source.HireGroupId,
                HireGroupCode = source.HireGroupCode,
                HireGroupName = source.HireGroupName,
                ParentHireGroupId = source.ParentHireGroupId,
                HireGroupDescription = source.Description,
                CompanyId = source.CompanyId,
                IsParent = source.IsParent,


            };
        }
        /// <summary>
        /// Add hire Group Request
        /// </summary>
        public static RequestModel.HireGroupAddRequest CreateFrom(this HireGroup source)
        {
            return new RequestModel.HireGroupAddRequest
            {
                HireGroupDetails = source.HireGroupDetailList!=null?source.HireGroupDetailList.Select(hg => hg.CreateFromForHireGroupAdd()):null,
                HireGroup = source.CreateFromAdd()
            };
        }

        #endregion

    }
}