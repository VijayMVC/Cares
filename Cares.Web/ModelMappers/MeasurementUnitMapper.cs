
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class MeasurementUnitMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static MeasurementUnit CreateFrom(this DomainModels.MeasurementUnit source)
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
        public static DomainModels.MeasurementUnit CreateFrom(this MeasurementUnit source)
        {
            if (source != null)
            {
                return new DomainModels.MeasurementUnit
                {
                    MeasurementUnitId = source.MeasurementUnitId,
                    MeasurementUnitName = source.MeasurementUnitName,
                };
            }
            return new DomainModels.MeasurementUnit();
        }

        #endregion
    }
}