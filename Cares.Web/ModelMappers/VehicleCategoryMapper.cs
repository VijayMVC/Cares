using Cares.Web.Models;
using DomainModels = Models.DomainModels;

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
        public static VehicleCategory CreateFrom(this DomainModels.VehicleCategory source)
        {
            return new VehicleCategory
            {
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategoryName = source.VehicleCategoryCode + "-" + source.VehicleCategoryName,
            };
        }
        #endregion
    }
}