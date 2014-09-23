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
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static HireGroupDropDown CreateFromHireGroupDropDown(this DomainModels.HireGroup source)
        {
            return new HireGroupDropDown
            {
                HireGroupId = source.HireGroupId,
                HireGroupCodeName = source.HireGroupCode + " - " + source.HireGroupName,
                CompanyId = source.CompanyId
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
                HireGroups = source.HireGroups.Select(hr => hr.CreateFromHireGroupDropDown())
            };
        }
        /// <summary>
        /// Hire Group Detail mapper for hire group web to entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Hire Group Mapper
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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
        public static DomainModels.HireGroup CreateFrom(this HireGroup source)
        {
            return new DomainModels.HireGroup
            {
                HireGroupDetails = source.HireGroupDetailList != null ? source.HireGroupDetailList.Select(hg => hg.CreateFromForHireGroupAdd()).ToList() : null,
                HireGroupUpGrades = source.HireGroupUpgradeList != null ? source.HireGroupUpgradeList.Select(h => h.CreateFrom()).ToList() : null,
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
        /// Hire Group detail data response Mapper that get get by hire group id
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HireGroupDataDetailResponse CreateFrom(this ResponseModel.HireGroupDataDetailResponse source)
        {
            return new HireGroupDataDetailResponse
                   {
                       HireGroupDetails = source.HireGroupDetails.Select(hg => hg.CreateFromForHireGroupDetail()),
                       HireGroupUpGrades = source.HireGroupUpGrades.Select(hgUpGrade => hgUpGrade.CreateFrom())
                   };
        }
        /// <summary>
        /// Hire Group Detail mapper for hire group web to entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HireGroupDetailForHireGroup CreateFromForHireGroupDetail(this DomainModels.HireGroupDetail source)
        {
            return new HireGroupDetailForHireGroup
            {
                HireGroupDetailId = source.HireGroupDetailId,
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleModelId = source.VehicleModelId,
                VehicleMakeId = source.VehicleMakeId,
                VehicleCategoryCodeName = source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName,
                VehicleModelCodeName = source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName,
                VehicleMakeCodeName = source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName,
                VehicleModelYear = source.ModelYear,

            };
        }
        /// <summary>
        /// Entitit to web Model 
        /// </summary>
        public static HireGroupUpgradeForHireGroup CreateFrom(this DomainModels.HireGroupUpGrade source)
        {
            return new HireGroupUpgradeForHireGroup
            {
                HireGroupCodeName = source.AllowedHireGroup.HireGroupCode + " - " + source.AllowedHireGroup.HireGroupName,
                HireGroupId = source.AllowedHireGroupId,
                HireGroupUpGradeId = source.HireGroupUpGradeId
            };
        }
        /// <summary>
        /// Entitit to web Model 
        /// </summary>
        public static DomainModels.HireGroupUpGrade CreateFrom(this HireGroupUpgradeForHireGroup source)
        {
            return new DomainModels.HireGroupUpGrade
            {
                HireGroupUpGradeId = source.HireGroupUpGradeId,
                AllowedHireGroupId = source.HireGroupId
            };
        }

        #endregion

    }
}