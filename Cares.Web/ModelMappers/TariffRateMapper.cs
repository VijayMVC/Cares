using System.Collections.Generic;
using System.Linq;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;
using DomainResponseModels = Cares.Models.ResponseModels;


namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Rate Mapper
    /// </summary>
    public static class TariffRateMapper
    {
        /// <summary>
        /// Create web model from entity
        /// </summary>
        public static ApiModel.TariffRateSearchResponse CreateFrom(this TariffRateResponse source)
        {
            return new ApiModel.TariffRateSearchResponse
            {
                TariffRates = source.TariffRates.Select(company => company.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #region Hire Group Deatil
        /// <summary>
        ///  Create web model from entity 
        /// </summary>
        public static ApiModel.HireGroupDetailResponse CreateFromHireGroupDetail(this HireGroupDetailResponse source)
        {
            IEnumerable<ApiModel.HireGroupDetailContent> hireGroupDetailContent = source.HireGroupDetails.Select(hireGroupDet => hireGroupDet.CreateFrom());
            IEnumerable<ApiModel.StandardRate> standardRates = source.StandardRates.Select(stRt => stRt.CreateFrom());
            // ReSharper disable once SuggestUseVarKeywordEvident
            List<ApiModel.HireGroupDetailContent> hireGroupDetails = new List<ApiModel.HireGroupDetailContent>();
            foreach (var hireGroupDetail in hireGroupDetailContent)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var standardRate in standardRates)
                {
                    if (standardRate.HireGroupDetailId == hireGroupDetail.HireGroupDetailId)
                    {
                        hireGroupDetail.StandardRtId = standardRate.StandardRtId;
                        hireGroupDetail.AllowMileage = standardRate.AllowMileage;
                        hireGroupDetail.ExcessMileageCharge = standardRate.ExcessMileageCharge;
                        hireGroupDetail.StandardRt = standardRate.StandardRt;
                        hireGroupDetail.StartDate = standardRate.StartDate;
                        hireGroupDetail.EndDate = standardRate.EndDt;
                        hireGroupDetail.IsChecked = true;
                        hireGroupDetail.RevisionNumber = standardRate.RevisionNumber;
                    }
                }
                hireGroupDetails.Add(hireGroupDetail);
            }
            return new ApiModel.HireGroupDetailResponse
            {
                HireGroupDetails = hireGroupDetails,

            };
        }
        #endregion
        #region Tariff Rate Base Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static ApiModel.TariffRateBaseResponse CreateFrom(this TariffRateBaseResponse source)
        {
            return new ApiModel.TariffRateBaseResponse
            {
                Companies = source.Companies.Select(company => company.CreateFrom()),
                Departments = source.Departments.Select(d => d.CreateFrom()),
                Operations = source.Operations.Select(operation => operation.CreateFrom()),
                HireGroups = source.HireGroups.Select(hireGroup => hireGroup.CreateFromForTariffRate()),
                VehicleMakes = source.VehicleMakes.Select(vehicleMake => vehicleMake.CreateFrom()),
                VehicleCategories = source.VehicleCategories.Select(o => o.CreateFrom()),
                VehicleModels = source.VehicleModels.Select(vehicleModel => vehicleModel.CreateFrom()),
                TariffTypes = source.TariffTypes.Select(tariffType => tariffType.CreateFromDropDown()).ToList(),
            };
        }
        #endregion
    }
}