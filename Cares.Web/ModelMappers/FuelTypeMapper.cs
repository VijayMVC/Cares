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
            if (source == null)
            {
                return null;
            }

            return new FuelType
            {
                FuelTypeId = source.FuelTypeId,
                FuelTypeName = source.FuelTypeName,
                FuelTypeCode = source.FuelTypeCode
            };
        }
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static FuelTypeDropDown CreateFromDropDown(this Cares.Models.DomainModels.FuelType source)
        {
            return new FuelTypeDropDown
            {
                FuelTypeId = source.FuelTypeId,
                FuelTypeCodeName = source.FuelTypeCode + " - " + source.FuelTypeName
            };
        }
        #endregion
    }
}