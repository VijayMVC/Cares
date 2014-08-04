using System.Linq;
using Cares.Web.Models;
using DomainResponseModels = Models.ResponseModels;
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
        public static TariffRateResponse CreateFrom(this DomainResponseModels.TariffRateResponse source)
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
        public static HireGroupDetailResponse CreateFromHireGroupDetail(this DomainResponseModels.HireGroupDetailResponse source)
        {
            return new HireGroupDetailResponse
            {
                HireGroupDetails = source.HireGroupDetails.Select(hireGroup => hireGroup.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }
        #endregion
        #region Tariff Rate Base Response Mapper
        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TariffRateBaseResponse CreateFrom(this DomainResponseModels.TariffRateBaseResponse source)
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