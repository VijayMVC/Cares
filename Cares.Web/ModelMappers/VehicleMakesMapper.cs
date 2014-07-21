using Cares.Web.Models;
using DomainModels = Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class VehicleMakesMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleMake CreateFrom(this DomainModels.VehicleMake source)
        {
            return new VehicleMake
            {
                VehicleMakeId = source.VehicleMakeId,
                VehicleMakeName = source.VehicleMakeCode + "-" + source.VehicleMakeName,
            };
        }

        #endregion
    }
}