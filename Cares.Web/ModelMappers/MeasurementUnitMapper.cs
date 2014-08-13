
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
        public static MeasurementUnitDropDown CreateFrom(this DomainModels.MeasurementUnit source)
        {
            return new MeasurementUnitDropDown
            {
                MeasurementUnitId = source.MeasurementUnitId,
                MeasurementUnitCodeName = source.MeasurementUnitCode+" - "+source.MeasurementUnitName,
            };
        }

           #endregion
    }
}