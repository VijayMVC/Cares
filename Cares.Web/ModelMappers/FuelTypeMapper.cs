using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Fuel Type Mapper
    /// </summary>
    public static class FuelTypeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static FuelType CreateFrom(this Cares.Models.DomainModels.FuelType source)
        {
            return new FuelType
            {
                FuelTypeId = source.FuelTypeId,
                FuelTypeName = source.FuelTypeName,
                FuelTypeCode = source.FuelTypeCode
            };
        }

        #endregion
    }
}