using Cares.Web.Models;
using DomainModels = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class VehicleModelMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleModel CreateFrom(this DomainModels.VehicleModel source)
        {
            return new VehicleModel
            {
                VehicleModeld = source.VehicleModeld,
                VehicleModelName = source.VehicleModelCode + "-" + source.VehicleModelName,
            };
        }

        #endregion
    }
}