using System.Collections.Generic;
using System.Linq;
using Cares.Web.Models;

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
        public static TariffRateResponse CreateFrom(this Cares.Models.ResponseModels.TariffRateResponse source)
        {
            return new TariffRateResponse
            {
                TariffRates = source.TariffRates.Select(company => company.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #region Hire Group Deatil
        /// <summary>
        ///  Create web model from entity 
        /// </summary>
        public static HireGroupDetailResponse CreateFromHireGroupDetail(this Cares.Models.ResponseModels.HireGroupDetailResponse source)
        {
            IEnumerable<HireGroupDetailContent> hireGroupDetailContent = source.HireGroupDetails.Select(hireGroupDet => hireGroupDet.CreateFrom());
            IEnumerable<StandardRate> standardRates = source.StandardRates.Select(stRt => stRt.CreateFrom());
            // ReSharper disable once SuggestUseVarKeywordEvident
            List<HireGroupDetailContent> hireGroupDetails = new List<HireGroupDetailContent>();
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
                    }
                }
                hireGroupDetails.Add(hireGroupDetail);
            }
            return new HireGroupDetailResponse
            {
                HireGroupDetails = hireGroupDetails,

            };
        }
        #endregion
        #region Tariff Rate Base Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TariffRateBaseResponse CreateFrom(this Cares.Models.ResponseModels.TariffRateBaseResponse source)
        {
            return new TariffRateBaseResponse
            {
                Companies = source.Companies.Select(company => company.CreateFrom()),
                Departments = source.Departments.Select(d => d.CreateFrom()),
                Operations = source.Operations.Select(operation => operation.CreateFrom()),
                HireGroups = source.HireGroups.Select(hireGroup => hireGroup.CreateFrom()),
                VehicleMakes = source.VehicleMakes.Select(vehicleMake => vehicleMake.CreateFrom()),
                VehicleCategories = source.VehicleCategories.Select(o => o.CreateFrom()),
                VehicleModels = source.VehicleModels.Select(vehicleModel => vehicleModel.CreateFrom()),
                TariffTypes = source.TariffTypes.Select(tariffType => tariffType.CreateFromForTariffRate()),
            };
        }
        #endregion
    }
}