using Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    public static class VehicleMakesMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleMake CreateFrom(this Cares.Models.DomainModels.VehicleMake source)
        {
            return new VehicleMake
            {
                VehicleMakeId = source.VehicleMakeId,
                VehicleMakeName = source.VehicleMakeName,
                VehicleMakeCode = source.VehicleMakeCode
            };
        }

        #endregion
    }
}