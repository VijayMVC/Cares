using DomainModels = Models.DomainModels;
using ApiModels = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Tarrif type mapper
    /// </summary>
    public static class TarrifTypeMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TarrifType CreateFrom(this DomainModels.TarrifType source)
        {
            return new ApiModels.TarrifType
            {

                TariffTypeId = source.TariffTypeId,
                Operation =
                    source.Operation != null
                        ? source.Operation.OperationCode + " - " + source.Operation.OperationName
                        : string.Empty,
                Company =
            source.Company != null
                ? source.Company.CompanyCode + " - " + source.Company.CompanyName
                : string.Empty,
                MeasurementUnit =
                    source.MeasurementUnit != null
                        ? source.MeasurementUnit.MeasurementUnitCode + " - " +
                          source.MeasurementUnit.MeasurementUnitName
                        : string.Empty,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                PricingScheme =
                    source.PricingStrategy != null
                        ? source.PricingStrategy.PricingStrategyCode + " - " +
                          source.PricingStrategy.PricingStrategyName
                        : string.Empty,
                DurationFrom = source.DurationFrom,
                DurationTo = source.DurationTo,
                GracePeriod = source.GracePeriod,
                EffectiveDate = source.EffectiveDate,
                RevisionNumber = source.RevisionNumber,


            };

        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.TarrifType CreateFrom(this ApiModels.TariffTypeDetail source)
        {
            return new DomainModels.TarrifType
            {
                TariffTypeId = source.TariffTypeId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
                CompanyId = source.CompanyId,
                OperationId = source.OperationId,
                MeasurementUnitId = source.MeasurementUnitId,
                DurationFrom = source.DurationFrom,
                DurationTo = source.DurationTo,
                GracePeriod = source.GracePeriod,
                EffectiveDate = source.EffectiveDate,
                PricingStrategyId = source.PricingStrategyId,
                RecCreatedDt = System.DateTime.Now,
                RecLastUpdatedDt = System.DateTime.Now,
                RevisionNumber = source.RevisionNumber,
                RecCreatedBy = "Cares"
            };


        }
        /// <summary>
        ///  Create Detail web model from entity
        /// </summary>
        public static ApiModels.TariffTypeDetail CreateFromDetail(this DomainModels.TarrifType source)
        {
            return new ApiModels.TariffTypeDetail
            {
                TariffTypeId = source.TariffTypeId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
                CompanyId = source.CompanyId,
                OperationId = source.OperationId,
                DepartmentId = source.Operation.DepartmentId,
                MeasurementUnitId = source.MeasurementUnitId,
                DurationFrom = source.DurationFrom,
                DurationTo = source.DurationTo,
                GracePeriod = source.GracePeriod,
                EffectiveDate = source.EffectiveDate,
                PricingStrategyId = source.PricingStrategyId,
                RevisionNumber = source.RevisionNumber,
                CreatedBy = source.RecCreatedBy,
                ModifiedBy = source.RecCreatedBy,
                ModifiedDate = source.RecLastUpdatedDt
            };

        }
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TarrifType CreateFromForTariffRate(this DomainModels.TarrifType source)
        {
            return new ApiModels.TarrifType
            {

                TariffTypeId = source.TariffTypeId,
                TariffTypeName = source.TariffTypeCode + "-" + source.TariffTypeName,
            };

        }
        #endregion
    }
}
