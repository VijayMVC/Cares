using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Movement Mapper
    /// </summary>
    public static class VehicleMovementMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleMovement CreateFrom(this DomainModels.VehicleMovement source)
        {
             return new VehicleMovement
            {
                VehicleMovementId = source.VehicleMovementId,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                Odometer = source.Odometer,
                RaHireGroupId = source.RaHireGroupId,
                VehicleStatusId = source.VehicleStatusId,
                DtTime = source.DtTime,
                FuelLevel = source.FuelLevel,
                Status = source.Status,
                VehicleCondition = source.VehicleCondition,
                VehicleConditionDescription = source.VehicleConditionDescription
            };
           
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.VehicleMovement CreateFrom(this VehicleMovement source)
        {
            return new DomainModels.VehicleMovement
            {
                VehicleMovementId = source.VehicleMovementId,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                Odometer = source.Odometer,
                RaHireGroupId = source.RaHireGroupId,
                VehicleStatusId = source.VehicleStatusId,
                DtTime = source.DtTime,
                FuelLevel = source.FuelLevel,
                Status = source.Status,
                VehicleCondition = source.VehicleCondition,
                VehicleConditionDescription = source.VehicleConditionDescription
            };

        }

        #endregion

    }
}
