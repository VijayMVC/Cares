using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
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
                VehicleModelCodeName = source.VehicleModelCode + " - " + source.VehicleModelName,
            };
        }

        #endregion
    }
}