using Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    public static class VehicleMakesMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleMakeDropDown CreateFrom(this Cares.Models.DomainModels.VehicleMake source)
        {
            return new VehicleMakeDropDown
            {
                VehicleMakeId = source.VehicleMakeId,
                VehicleMakeName = source.VehicleMakeName,
                VehicleMakeCode = source.VehicleMakeCode
            };
        }

        #endregion
    }
}