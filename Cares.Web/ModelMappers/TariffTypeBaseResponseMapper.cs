using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tariff Type Base Response Mapper
    /// </summary>
    public static class TariffTypeBaseResponseMapper
    {
        #region Public

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static TarrifTypeBaseResponse CreateFrom(this Cares.Models.ResponseModels.TarrifTypeBaseResponse source)
        {
            return new TarrifTypeBaseResponse
            {
                ResponseCompanies = source.Companies.Select(c => c.CreateFrom()),
                ResponseMeasurementUnits = source.MeasurementUnits.Select(m => m.CreateFrom()),
                ResponseDepartments = source.Departments.Select(d => d.CreateFrom()),
                ResponseOperations = source.Operations.Select(o => o.CreateFrom()),
                ResponsePricingStrategies = source.PricingStrategies.Select(p => p.CreateFrom()),
            };
        }

        #endregion
    }
}