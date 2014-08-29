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
        
        /// <summary>
        /// Create Vehicle Search Response from domain Vehicle Search Response
        /// </summary>
        public static GetVehicleResponse CreateFrom(this ResponseModel.GetVehicleResponse source)
        {
            return new GetVehicleResponse
            {
                Vehicles = source.Vehicles.Select(hg => hg.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }

        #endregion

        #region Vehicle Base Data Response

        /// <summary>
        /// Domain Response To Web Response
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleBaseDataResponse CreateFrom(this ResponseModel.VehicleBaseDataResponse source)
        {
            return new VehicleBaseDataResponse
                   {
                       Operations = source.Operations.Select(op => op.CreateFrom()),
                       FleetPools = source.FleetPools.Select(fp => fp.CreateFromm()),
                       Companies = source.Companies.Select(comp => comp.CreateFrom()),
                       Regions = source.Regions.Select(r => r.CreateFrom()),
                       FuelTypes = source.FuelTypes.Select(ft => ft.CreateFromDropDown()),
                       VehicleModels = source.VehicleModels.Select(vm => vm.CreateFrom()),
                       VehicleStatuses = source.VehicleStatuses.Select(vs => vs.CreateFromDropDown()),
                       Departments = source.Departments.Select(d => d.CreateFrom()),
                       VehicleCategories = source.VehicleCategories.Select(vc => vc.CreateFrom()),
                       TransmissionTypes = source.TransmissionTypes.Select(tt => tt.CreateFromDropDown()),
                       VehicleMakes = source.VehicleMakes.Select(vm => vm.CreateFrom()),
                       BusinessPartners = source.BusinessPartners.Select(bp => bp.CreateDropDownModelFrom()),
                       InsuranceType = source.InsuranceType.Select(it => it.CreateFromDropDown()),
                       MaintenanceTypes = source.MaintenanceTypes.Select(mt => mt.CreateFromDropDown()),
                       VehicleCheckList = source.VehicleCheckList.Select(vcl => vcl.CreateFromDropDown())
                   };
        }

        #endregion
    }
}