using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Category Mapper
    /// </summary>
    public static class VehicleCategoryMapper
    {
        #region Public
/// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleCategory CreateFrom(this Cares.Models.DomainModels.VehicleCategory source)
        {
            return new VehicleCategory
            {
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategoryCodeName = source.VehicleCategoryCode + " - " + source.VehicleCategoryName,
            };
        }
        #endregion
    }
}