
using TarrifType = Cares.Web.Models.TarrifType;

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
        public static TarrifType CreateFrom(this global::Models.DomainModels.TarrifType source)
        {
            return new TarrifType
            {
        
                TariffTypeId = source.TariffTypeId,
                UserDomainKey = source.UserDomainKey,
                OperationId = source.OperationId,
                MeasurementUnitId = source.MeasurementUnitId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
                PricingStrategyId = source.PricingStrategyId,
                DurationFrom = source.DurationFrom,
                DurationTo = source.DurationTo,
                GracePeriod = source.GracePeriod,
                EffectiveDate = source.EffectiveDate,
                RowVersion = source.RowVersion,
                RevisionNumber = source.RevisionNumber,
                ChildTariffTypeId = source.ChildTariffTypeId,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
                RecCreatedBy = source.RecCreatedBy,
                IsActive = source.IsActive,
                IsDeleted = source.IsDeleted,
                IsPrivate = source.IsPrivate,
                IsReadOnly = source.IsReadOnly
                
            };

        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.TarrifType CreateFrom(this TarrifType source)
        {
            return new global::Models.DomainModels.TarrifType
            {
                TariffTypeId = source.TariffTypeId,
                UserDomainKey = source.UserDomainKey,
                OperationId = source.OperationId,
                MeasurementUnitId = source.MeasurementUnitId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
                PricingStrategyId = source.PricingStrategyId,
                DurationFrom = source.DurationFrom,
                DurationTo = source.DurationTo,
                GracePeriod = source.GracePeriod,
                EffectiveDate = source.EffectiveDate,
                RowVersion = source.RowVersion,
                RevisionNumber = source.RevisionNumber,
                ChildTariffTypeId = source.ChildTariffTypeId,
                RecCreatedDt = source.RecCreatedDt,
                RecLastUpdatedDt = source.RecLastUpdatedDt,
                RecCreatedBy = source.RecCreatedBy,
                IsActive = source.IsActive,
                IsDeleted = source.IsDeleted,
                IsPrivate = source.IsPrivate,
                IsReadOnly = source.IsReadOnly
            };

        }

        #endregion
    }
}