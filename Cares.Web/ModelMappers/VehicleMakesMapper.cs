using System.Linq;
using Cares.Web.Models;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Make Mapper
    /// </summary>
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
                VehicleMakeCodeName = source.VehicleMakeCode + "-" + source.VehicleMakeName
            };
        }


        /// <summary>
        /// Create from domain model
        /// </summary>
        public static VehicleMake CreateFromm(this Cares.Models.DomainModels.VehicleMake source)
        {
            return new VehicleMake
            {
                VehicleMakeId = source.VehicleMakeId,
                VehicleMakeCode = source.VehicleMakeCode,
                VehicleMakeName = source.VehicleMakeName,
                VehicleMakeDescription = source.VehicleMakeDescription
            };
        }

        /// <summary>
        /// Create from web model
        /// </summary>
        public static Cares.Models.DomainModels.VehicleMake CreateFrom(this VehicleMake source)
        {
            return new Cares.Models.DomainModels.VehicleMake
            {

                VehicleMakeId = source.VehicleMakeId,
                VehicleMakeCode = source.VehicleMakeCode,
                VehicleMakeName = source.VehicleMakeName,
                VehicleMakeDescription = source.VehicleMakeDescription
            };
        }

        /// <summary>
        /// Create from web model
        /// </summary>
        public static VehicleMakeSearchRequestResponse CreateFromm(this Cares.Models.ResponseModels.VehicleMakeSearchRequestResponse source)
        {
            return new VehicleMakeSearchRequestResponse
            {
                VehicleMakes = source.VehicleMakes.Select(vehiclemake => vehiclemake.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        #endregion
    }
}