using System.Linq;
using Cares.Web.Models;
using DomainResponseModels = Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Rate Base Response Mapper
    /// </summary>
    public static class TariffRateBaseResponseMapper
    {
        #region Public
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