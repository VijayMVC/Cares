using System.Linq;
using DomainModel = Cares.Models.DomainModels;
using DomainResponseModel = Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Non revenue Ticket Mapper
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class NRTMapper
    {
        #region Public
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.NrtMain CreateFrom(this ApiModel.NrtMain source)
        {

            return new DomainModel.NrtMain
            {
                NrtMainId = source.NrtMainId,
                OpenLocationId = source.OpenLocationId,
                CloseLocationId = source.CloseLocationId,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                NrtTypeId = source.NrtTypeId,

            };
        }
        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.NrtVehicle CreateFrom(this ApiModel.NrtVehicle source)
        {

            return new DomainModel.NrtVehicle
            {
                VehicleId = source.VehicleId,
                NrtMainId = source.NrtMainId,
                NrtCharges = source.NrtCharges.Select(c => c.CreateFrom()).ToList(),
                NrtDrivers = source.NrtDrivers.Select(c => c.CreateFrom()).ToList(),
                NrtVehicleMovements = source.NrtVehicleMovements.Select(c => c.CreateFrom()).ToList(),
                NrtMain = source.NrtMain.CreateFrom(),
            };
        }

        /// <summary>
        /// Web To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.NrtDriver CreateFrom(this ApiModel.NrtDriver source)
        {
            return new DomainModel.NrtDriver
            {
                NrtDriverId = source.NrtDriverId,
                ChaufferId = source.ChaufferId,
                DesigGradeId = source.DesigGradeId,
                StartDtTime = source.StartDtTime,
                EndDtTime = source.EndDtTime,
                LicenseExpDt = source.LicenseExpDt,
                LicenseNo = source.LicenseNo
            };
        }

        /// <summary>
        /// Web To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.NrtCharge CreateFrom(this ApiModel.NrtCharge source)
        {
            return new DomainModel.NrtCharge
            {
                NrtChargeId = source.NrtChargeId,
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                ContactPerson = source.ContactPerson,
                Description = source.Description,
                NrtChargeRate = source.NrtChargeRate,
                TotalNrtChargeRate = source.TotalNrtChargeRate,
                Quantity = source.Quantity,
            };
        }

        /// <summary>
        /// Web To Domain Model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModel.NrtVehicleMovement CreateFrom(this ApiModel.NrtVehicleMovement source)
        {
            return new DomainModel.NrtVehicleMovement
            {
                NrtVehicleMovementId = source.NrtVehicleMovementId,
                DtTime = source.DtTime,
                FuelLevel = source.FuelLevel,
                Odometer = source.Odometer,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                VehicleStatusId = source.VehicleStatusId,
            };
        }
        #endregion
        #region  Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ApiModel.NRTBaseResponse CreateFrom(this DomainResponseModel.NRTBaseResponse source)
        {
            return new ApiModel.NRTBaseResponse
            {
                Operations = source.Operations.Select(c => c.CreateFrom()).ToList(),
                Locations = source.Locations.Select(c => c.CreateFromDropDown()).ToList(),
                NRTTypes = source.NRTTypes.Select(c => c.CreateFrom()).ToList(),
                VehicleStatuses = source.VehicleStatuses.Select(c => c.CreateFromm()).ToList(),
            };
        }
        #endregion
    }
}