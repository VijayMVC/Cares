using System.Linq;
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;
using ResponseModel = Cares.Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    public static class VehicleMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Vehicle CreateFrom(this DomainModels.Vehicle source, bool headerOnly = true)
        {
            DomainModels.VehicleImage image = source.HireGroup != null ? 
                source.HireGroup.HireGroupDetails.Select(hg => hg.VehicleImageHireGroupDetails.Select(hgd => hgd.VehicleImage)
                    .FirstOrDefault()).FirstOrDefault() : new DomainModels.VehicleImage();

            Vehicle vehicle = new Vehicle
            {
                VehicleId = source.VehicleId,
                VehicleName = source.VehicleName,
                VehicleCode = source.VehicleCode,
                IsBranchOwner = source.IsBranchOwner,
                PlateNumber = source.PlateNumber,
                CurrentOdometer = source.CurrentOdometer,
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategory = source.VehicleCategory.CreateFrom(),
                VehicleMakeId = source.VehicleMakeId,
                VehicleMake = source.VehicleMake.CreateFrom(),
                VehicleModelId = source.VehicleModelId,
                VehicleModel = source.VehicleModel.CreateFrom(),
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatus = source.VehicleStatus.CreateFrom(),
                ModelYear = source.ModelYear,
                Image = image != null ? image.Image : new byte[] { }
            };

            // If Details are not required
            if (headerOnly)
            {
                return vehicle;
            }

            // Map Details
            vehicle.InitialOdometer = source.InitialOdometer;
            vehicle.FleetPoolId = source.FleetPoolId;
            vehicle.FleetPool = source.FleetPool.CreateFrom();
            vehicle.FuelLevel = source.FuelLevel;
            vehicle.FuelTypeId = source.FuelTypeId;
            vehicle.FuelType = source.FuelType.CreateFrom();
            vehicle.TransmissionTypeId = source.TransmissionTypeId;
            vehicle.TransmissionType = source.TransmissionType.CreateFrom();
            vehicle.OperationId = source.OperationsWorkPlace.OperationId;
            vehicle.Operation = source.OperationsWorkPlace.Operation.CreateFrom();
            vehicle.OperationsWorkPlaceId = source.OperationsWorkPlaceId;
            vehicle.OperationsWorkPlace = source.OperationsWorkPlace.CreateFrom();
            vehicle.RegistrationDate = source.RegistrationDate;
            vehicle.RegistrationExpiryDate = source.RegistrationExpiryDate;
            vehicle.VehicleCondition = source.VehicleCondition;
            vehicle.VehicleConditionDescription = source.VehicleConditionDescription;
            vehicle.Color = source.Color;
            vehicle.TankSize = source.TankSize;

            return vehicle;
        }
        
        #endregion
    }
}