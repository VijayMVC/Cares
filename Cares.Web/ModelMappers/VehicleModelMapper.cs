using System.Linq;
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
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static VehicleModelDropDown CreateFrom(this Cares.Models.DomainModels.VehicleModel source)
        {
            return new VehicleModelDropDown
            {
                VehicleModeld = source.VehicleModelId,
                VehicleModelCodeName = source.VehicleModelCode + "-" + source.VehicleModelName
            };
        }

        /// <summary>
        /// Create From Domain Model
        /// </summary>
        public static VehicleModel CreateVehicleModelFrom(this Cares.Models.DomainModels.VehicleModel source)
        {
            return new VehicleModel
            {
                VehicleModelId=source.VehicleModelId,
                VehicleModelCode = source.VehicleModelCode,
                VehicleModelName = source.VehicleModelName,
                VehicleModelDescription = source.VehicleModelDescription
            };
        }

        /// <summary>
        /// Create From Web model
        /// </summary>
        public static Cares.Models.DomainModels.VehicleModel CreateFrom(this VehicleModel source)
        {
            return new Cares.Models.DomainModels.VehicleModel
            {
                VehicleModelId = source.VehicleModelId,
                VehicleModelCode = source.VehicleModelCode.Trim(),
                VehicleModelName = source.VehicleModelName,
                VehicleModelDescription = source.VehicleModelDescription
            };
        }

        /// <summary>
        /// Crete from domain search request response
        /// </summary>
        public static VehicleModelSearcgRequestResponse CreateFrom(this Cares.Models.ResponseModels.VehicleModelSearcgRequestResponse source)
        {
            return new VehicleModelSearcgRequestResponse
            {
                TotalCount = source.TotalCount,
                VehicleModels = source.VehicleModels.Select(vehiclemodel => vehiclemodel.CreateVehicleModelFrom())
            };
        }


        #endregion
    }
}