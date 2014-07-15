
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class MeasurementUnitMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static MeasurementUnit CreateFrom(this global::Models.DomainModels.MeasurementUnit source)
        {
            return new MeasurementUnit
            {
                MeasurementUnitId = source.MeasurementUnitId,
                MeasurementUnitName = source.MeasurementUnitName,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.MeasurementUnit CreateFrom(this MeasurementUnit source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.MeasurementUnit
                {
                    MeasurementUnitId = source.MeasurementUnitId,
                    MeasurementUnitName = source.MeasurementUnitName,
                };
            }
            return new global::Models.DomainModels.MeasurementUnit();
        }

        #endregion
    }
}