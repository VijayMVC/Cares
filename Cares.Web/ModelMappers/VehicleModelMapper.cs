using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Model Mapper
    /// </summary>
    public static class VehicleModelMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleModel CreateFrom(this Cares.Models.DomainModels.VehicleModel source)
        {
            return new VehicleModel
            {
                VehicleModeld = source.VehicleModelId,
                VehicleModelName = source.VehicleModelName,
                VehicleModelCode = source.VehicleModelCode
            };
        }

        #endregion
    }
}