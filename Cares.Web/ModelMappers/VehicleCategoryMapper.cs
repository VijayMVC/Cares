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
        public static VehicleCategoryDropDown CreateFrom(this Cares.Models.DomainModels.VehicleCategory source)
        {
            return new VehicleCategoryDropDown
            {
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategoryName = source.VehicleCategoryName,
                VehicleCategoryCode = source.VehicleCategoryCode
            };
        }
        
        #endregion
    }
}