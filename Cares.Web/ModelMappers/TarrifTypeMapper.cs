using System.Linq;
using Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModels = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// tariff type mapper
    /// </summary>
    public static class TariffTypeMapper
    {
        #region tariff Type
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TariffType CreateFrom(this TariffType source)
        {
            return new ApiModels.TariffType
            {

                TariffTypeId = source.TariffTypeId,
                Operation =
                    source.Operation != null
                        ? source.Operation.OperationCode + " - " + source.Operation.OperationName
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
        public static TariffType CreateFrom(this ApiModels.TariffTypeDetail source)
        {
            return new TariffType
            {
                TariffTypeId = source.TariffTypeId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
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
        public static ApiModels.TariffTypeDetail CreateFromDetail(this TariffType source)
        {
            return new ApiModels.TariffTypeDetail
            {
                TariffTypeId = source.TariffTypeId,
                TariffTypeCode = source.TariffTypeCode,
                TariffTypeName = source.TariffTypeName,
                TariffTypeDescription = source.TariffTypeDescription,
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
                ModifiedDate = source.RecLastUpdatedDt,
                CreatedDate = source.RecCreatedDt
            };

        }
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TariffType CreateFromForTariffRate(this TariffType source)
        {
            return new ApiModels.TariffType
            {

                TariffTypeId = source.TariffTypeId,
                TariffTypeName = source.TariffTypeCode + "-" + source.TariffTypeName,
            };

        }
        #endregion
        #region Base Response Mapper

        /// <summary>
        ///  Tariff Type Base Response Mapper
        /// </summary>
        public static ApiModels.TariffTypeBaseResponse CreateFrom(this DomainResponseModel.TariffTypeBaseResponse source)
        {
            return new ApiModels.TariffTypeBaseResponse
            {
                ResponseCompanies = source.Companies.Select(c => c.CreateFrom()),
                ResponseMeasurementUnits = source.MeasurementUnits.Select(m => m.CreateFrom()),
                ResponseDepartments = source.Departments.Select(d => d.CreateFrom()),
                ResponseOperations = source.Operations.Select(o => o.CreateFrom()),
                ResponsePricingStrategies = source.PricingStrategies.Select(p => p.CreateFrom()),
            };
        }

        #endregion
        #region Detail Response Mapper

        /// <summary>
        ///  tariff Type Detail Response Mapper
        /// </summary>
        public static ApiModels.TariffTypeDetailResponse CreateFrom(this DomainResponseModel.TariffTypeDetailResponse source)
        {
            return new ApiModels.TariffTypeDetailResponse
            {
                TariffType = source.TariffType.CreateFromDetail(),
                TariffTypeRevisions = source.TariffTypeRevisions != null ? source.TariffTypeRevisions.Select(m => m.CreateFromDetail()) : null,

            };
        }

        #endregion
        #region Response Mapper For List
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModels.TariffTypeSearchResponse CreateFrom(this DomainResponseModel.TariffTypeResponse source)
        {
            return new ApiModels.TariffTypeSearchResponse
            {
                TotalCount = source.TotalCount,
                ServertariffTypes = source.TariffTypes.Select(p => p.CreateFrom())
            };

        }
        #endregion
    }
}
