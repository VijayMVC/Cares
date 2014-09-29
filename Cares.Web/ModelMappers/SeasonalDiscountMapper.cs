using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Seasonal Discount Mapper
    /// </summary>
    public static class SeasonalDiscountMapper
    {
        #region Public
        /// <summary>
        /// Domain Model To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.SeasonalDiscountMainContent CreateFrom(this DomainResponseModel.SeasonalDiscountMainContent source)
        {
            return new ApiModel.SeasonalDiscountMainContent
            {
                SeasonalDiscountMainId = source.SeasonalDiscountMainId,
                Code = source.Code,
                Name = source.Name,
                CompanyId = source.CompanyId,
                CompanyCodeName = source.CompanyCodeName,
                DepartmentId = source.DepartmentId,
                OperationId = source.OperationId,
                OperationCodeName = source.OperationCodeName,
                TariffTypeId = source.TariffTypeId,
                TariffTypeCodeName = source.TariffTypeCodeName,
                Description = source.Description,
                StartDt = source.StartDt,
                EndDt = source.EndDt,
            };
        }

        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.SeasonalDiscountMain CreateFrom(this ApiModel.SeasonalDiscountMain source)
        {
            return new DomainModel.SeasonalDiscountMain
            {
                SeasonalDiscountMainId = source.SeasonalDiscountMainId,
                SeasonalDiscountMainCode = source.Code,
                SeasonalDiscountMainName = source.Name,
                TariffTypeCode = source.TariffTypeCode,
                SeasonalDiscountMainDescription = source.Description,
                StartDt = source.StartDt,
                EndDt = source.EndDt,
                SeasonalDiscounts = source.SeasonalDiscounts != null ? source.SeasonalDiscounts.Select(c => c.CreateFrom()).ToList() : null
            };
        }

        /// <summary>
        /// Web Model To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.SeasonalDiscount CreateFrom(this ApiModel.SeasonalDiscount source)
        {
            return new DomainModel.SeasonalDiscount
            {
                SeasonalDiscountId = source.SeasonalDiscountId,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                VehicleCategoryId = source.VehicleCategoryId,
                BpRatingTypeId = source.RatingTypeId,
                VehicleMakeId = source.VehicleMakeId,
                VehicleModelId = source.VehicleModelId,
                HireGroupId = source.HireGroupId,
                CustomerType = source.CustomerType,
                ModelYear = source.ModelYear,
                DiscountPerc = source.DiscountPerc,
                SeasonalDiscountStartDt = source.StartDt,
                SeasonalDiscountEndDt = source.EndDt,
            };
        }

        /// <summary>
        /// Domain Model To Web Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.SeasonalDiscount CreateFrom(this DomainModel.SeasonalDiscount source)
        {
            return new ApiModel.SeasonalDiscount
            {
                SeasonalDiscountId = source.SeasonalDiscountId,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                VehicleCategoryId = source.VehicleCategoryId,
                RatingTypeId = source.BpRatingTypeId,
                VehicleMakeId = source.VehicleMakeId,
                VehicleModelId = source.VehicleModelId,
                HireGroupId = source.HireGroupId,
                CustomerType = source.CustomerType,
                ModelYear = source.ModelYear,
                DiscountPerc = source.DiscountPerc,
                StartDt = source.SeasonalDiscountStartDt,
                EndDt = source.SeasonalDiscountEndDt,
            };
        }

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.SeasonalDiscountSearchResponse CreateFrom(this DomainResponseModel.SeasonalDiscountSearchResponse source)
        {
            return new ApiModel.SeasonalDiscountSearchResponse
            {
                SeasonalDiscountMains = source.SeasonalDiscountMains.Select(c => c.CreateFrom()).ToList(),
                TotalCount = source.TotalCount
            };
        }
        #endregion

        #region  Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.SeasonalDiscountBaseResponse CreateFrom(this DomainResponseModel.SeasonalDiscountBaseResponse source)
        {
            return new ApiModel.SeasonalDiscountBaseResponse
            {
                Companies = source.Companies.Select(c => c.CreateFrom()).ToList(),
                Departments = source.Departments.Select(c => c.CreateFrom()).ToList(),
                Operations = source.Operations.Select(c => c.CreateFrom()).ToList(),
                TariffTypes = source.TariffTypes.Select(c => c.CreateFromDropDown()).ToList(),
                OperationsWorkPlaces = source.OperationsWorkPlaces.Select(c => c.CreateFromDropDown()).ToList(),
                HireGroups = source.HireGroups.Select(c => c.CreateFromHireGroupDropDown()).ToList(),
                VehicleCategories = source.VehicleCategories.Select(c => c.CreateFrom()).ToList(),
                VehicleMakes = source.VehicleMakes.Select(c => c.CreateFrom()).ToList(),
                VehicleModels = source.VehicleModels.Select(c => c.CreateFrom()).ToList(),
                BpRatingTypes = source.BpRatingTypes.Select(c => c.CreateFrom()).ToList(),

            };
        }
        #endregion
    }
}