using System.Linq;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Status Mapper
    /// </summary>
    public static class VehicleStatusMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleStatus CreateFrom(this Cares.Models.DomainModels.VehicleStatus source)
        {
            return new VehicleStatus
            {
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatusName = source.VehicleStatusName,
                VehicleStatusCode = source.VehicleStatusCode,
                VehicleStatusDescription = source.VehicleStatusDescription
            };
        }

        /// <summary>
        ///  Create web model from entity [dropdown]
        /// </summary>
        public static VehicleStatusDropDown CreateFromm(this Cares.Models.DomainModels.VehicleStatus source)
        {
            return new VehicleStatusDropDown
            {
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatusCodeName = source.VehicleStatusCode+" - "+source.VehicleStatusName
            };
        }

        /// <summary>
        ///  Create From web model 
        /// </summary>
        public static Cares.Models.DomainModels.VehicleStatus CreateFrom(this VehicleStatus source)
        {
            return new Cares.Models.DomainModels.VehicleStatus
            {
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatusName = source.VehicleStatusName,
                VehicleStatusCode = source.VehicleStatusCode,
                VehicleStatusDescription = source.VehicleStatusDescription
            };
        }

        /// <summary>
        /// Create From Domain search request response
        /// </summary>
        public static VehicleStatusSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.VehicleStatusSearchRequestResponse source)
        {

            return new VehicleStatusSearchRequestResponse
            {
                TotalCount = source.TotalCount,
               VehicleStatuses = source.VehicleStatuses.Select(vehicleStatus => vehicleStatus.CreateFrom())
            };
        }
        #endregion
    }
}