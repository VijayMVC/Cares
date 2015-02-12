using System;
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
            DomainModels.VehicleImage image = source.VehicleImages != null ? source.VehicleImages.FirstOrDefault() : new DomainModels.VehicleImage();

            Vehicle vehicle = new Vehicle
            {
                VehicleId = source.VehicleId,
                VehicleName = source.VehicleName,
                VehicleCode = source.VehicleCode,
                IsBranchOwner = source.IsBranchOwner,
                PlateNumber = source.PlateNumber,
                CurrentOdometer = source.CurrentOdometer,
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleCategory = source.VehicleCategory != null ? source.VehicleCategory.CreateFrom() : new VehicleCategoryDropDown(),
                VehicleMakeId = source.VehicleMakeId,
                VehicleMake = source.VehicleMake != null ? source.VehicleMake.CreateFrom() : new VehicleMakeDropDown(),
                VehicleModelId = source.VehicleModelId,
                VehicleModel = source.VehicleModel != null ? source.VehicleModel.CreateFrom() : new VehicleModelDropDown(),
                VehicleStatusId = source.VehicleStatusId,
                VehicleStatus = source.VehicleStatus != null ? source.VehicleStatus.CreateFrom() : new VehicleStatus(),
                ModelYear = source.ModelYear,
                Image = image != null ? image.Image : null
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
            vehicle.TransmissionType = source.TransmissionType != null ? source.TransmissionType.CreateFrom() : new TransmissionType();
            vehicle.OperationId = source.OperationsWorkPlace != null ? (int)source.OperationsWorkPlace.OperationId : 0;
            vehicle.Operation = source.OperationsWorkPlace != null && source.OperationsWorkPlace.Operation != null ?
                source.OperationsWorkPlace.Operation.CreateFrom() : new OperationDropDown();
            vehicle.OperationsWorkPlaceId = source.OperationsWorkPlaceId;
            vehicle.OperationsWorkPlace = source.OperationsWorkPlace != null ? source.OperationsWorkPlace.CreateFrom() : new OperationsWorkPlace();
            vehicle.RegistrationDate = source.RegistrationDate;
            vehicle.RegistrationExpiryDate = source.RegistrationExpiryDate;
            vehicle.VehicleCondition = source.VehicleCondition;
            vehicle.VehicleConditionDescription = source.VehicleConditionDescription;
            vehicle.Color = source.Color;
            vehicle.TankSize = source.TankSize;

            return vehicle;
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleListViewContent CreateFromListViewContent(this DomainModels.Vehicle source)
        {

            return new VehicleListViewContent
            {
                VehicleId = source.VehicleId,
                VehicleName = source.VehicleName,
                PlateNumber = source.PlateNumber,
                CurrentOdometer = source.CurrentOdometer,
                FuelLevel = source.FuelLevel,
                ModelYear = source.ModelYear,
                Location = source.OperationsWorkPlace != null ? source.OperationsWorkPlace.LocationCode : string.Empty,
                VehicleMakeCodeName = source.VehicleMake != null ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName : string.Empty,
                VehicleStatusCodeName = source.VehicleStatus != null ? source.VehicleStatus.VehicleStatusCode + " - " + source.VehicleStatus.VehicleStatusName : string.Empty,
                FleetPoolCodeName = source.FleetPool != null ? source.FleetPool.FleetPoolCode + " - " + source.FleetPool.FleetPoolName : string.Empty,
                OperationCodeName = source.OperationsWorkPlace != null ? source.OperationsWorkPlace.Operation.OperationCode + " - " + source.OperationsWorkPlace.Operation.OperationName : string.Empty,

            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Vehicle CreateFromForNrt(this DomainModels.Vehicle source)
        {

            return new Vehicle
            {
                VehicleId = source.VehicleId,
                VehicleName = source.VehicleName,
                PlateNumber = source.PlateNumber,
                TankSize = source.TankSize,
                CurrentOdometer = source.CurrentOdometer,
                FuelLevel = source.FuelLevel,
                ModelYear = source.ModelYear,
                VehicleMakeCodeName = source.VehicleMake != null ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName : string.Empty,
                VehicleStatusCodeName = source.VehicleStatus != null ? source.VehicleStatus.VehicleStatusCode + " - " + source.VehicleStatus.VehicleStatusName : string.Empty,
                VehicleModelCodeName = source.VehicleModel != null ? source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName : string.Empty,
                VehicleCategoryCodeName = source.VehicleCategory != null ? source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName : string.Empty,

            };
        }


        /// <summary>
        /// Create Vehicle Search Response from domain Vehicle Search Response
        /// </summary>
        public static GetVehicleResponse CreateFrom(this ResponseModel.GetVehicleResponse source)
        {
            return new GetVehicleResponse
            {
                Vehicles = source.Vehicles.Select(hg => hg.CreateFromListViewContent()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create Vehicle Search Response from domain Vehicle Search Response
        /// </summary>
        public static HireGroupVehiclesResponse CreateFromFoRa(this ResponseModel.GetVehicleResponse source)
        {
            return new HireGroupVehiclesResponse
            {
                Vehicles = source.Vehicles.Select(hg => hg.CreateFrom(false)),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.Vehicle CreateFrom(this VehicleDetail source)
        {
            return new DomainModels.Vehicle
                   {
                       VehicleId = source.VehicleId,
                       IsBranchOwner = source.IsBranchOwner,
                       PlateNumber = source.PlateNumber,
                       VehicleName = source.VehicleName,
                       ModelYear = source.ModelYear,
                       FleetPoolId = source.FleetPoolId,
                       Color = source.Color,
                       OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                       FuelLevel = source.FuelLevel,
                       TankSize = source.TankSize,
                       InitialOdometer = source.InitialOdometer,
                       CurrentOdometer = source.CurrentOdometer,
                       RegistrationDate = source.RegistrationDate,
                       VehicleMakeId = source.VehicleMakeId,
                       VehicleCategoryId = source.VehicleCategoryId,
                       VehicleModelId = source.VehicleModelId,
                       VehicleStatusId = source.VehicleStatusId,
                       FuelTypeId = source.FuelTypeId,
                       TransmissionTypeId = source.TransmissionTypeId,
                       RegistrationExpiryDate = source.RegistrationExpiryDate,
                       VehicleCondition = source.VehicleCondition,
                       VehicleOtherDetail = source.VehicleOtherDetail.CreateFrom(),
                       VehiclePurchaseInfo = source.VehiclePurchaseInfo.CreateFrom(),
                       VehicleLeasedInfo = source.VehicleLeasedInfo.CreateFrom(),
                       VehicleInsuranceInfo = source.VehicleInsuranceInfo.CreateFrom(),
                       VehicleDepreciation = source.VehicleDepreciation.CreateFrom(),
                       VehicleDisposalInfo = source.VehicleDisposalInfo.CreateFrom(),
                       VehicleMaintenanceTypeFrequencies = source.VehicleMaintenanceTypeFrequency != null ? source.VehicleMaintenanceTypeFrequency.Select(vm => vm.CreateFrom()).ToList() : null,
                       VehicleCheckListItems = source.VehicleCheckListItems != null ? source.VehicleCheckListItems.Select(vm => vm.CreateFrom()).ToList() : null,
                       VehicleImages = source.VehicleImages != null ? source.VehicleImages.Select(mt => mt.CreateFrom()).ToList() : null,
                   };
        }

        /// <summary>
        /// Create web model from entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleDetail CreateFromDetail(this DomainModels.Vehicle source)
        {
            return new VehicleDetail
            {
                VehicleId = source.VehicleId,
                IsBranchOwner = source.IsBranchOwner,
                PlateNumber = source.PlateNumber,
                VehicleName = source.VehicleName,
                ModelYear = source.ModelYear,
                FleetPoolId = source.FleetPoolId,
                Color = source.Color,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                FuelLevel = source.FuelLevel,
                TankSize = source.TankSize,
                InitialOdometer = source.InitialOdometer,
                CurrentOdometer = source.CurrentOdometer,
                RegistrationDate = source.RegistrationDate,
                VehicleMakeId = source.VehicleMakeId,
                VehicleCategoryId = source.VehicleCategoryId,
                VehicleModelId = source.VehicleModelId,
                VehicleStatusId = source.VehicleStatusId,
                FuelTypeId = source.FuelTypeId,
                TransmissionTypeId = source.TransmissionTypeId,
                RegistrationExpiryDate = source.RegistrationExpiryDate,
                VehicleCondition = source.VehicleCondition,
                VehicleOtherDetail = source.VehicleOtherDetail != null ? source.VehicleOtherDetail.CreateFrom() : null,
                VehiclePurchaseInfo = source.VehiclePurchaseInfo != null ? source.VehiclePurchaseInfo.CreateFrom() : null,
                VehicleLeasedInfo = source.VehicleLeasedInfo != null ? source.VehicleLeasedInfo.CreateFrom() : null,
                VehicleInsuranceInfo = source.VehicleInsuranceInfo != null ? source.VehicleInsuranceInfo.CreateFrom() : null,
                VehicleDepreciation = source.VehicleDepreciation != null ? source.VehicleDepreciation.CreateFrom() : null,
                VehicleDisposalInfo = source.VehicleDisposalInfo != null ? source.VehicleDisposalInfo.CreateFrom() : null,
                VehicleMaintenanceTypeFrequency = source.VehicleMaintenanceTypeFrequencies != null ? source.VehicleMaintenanceTypeFrequencies.Select(mt => mt.CreateFrom()).ToList() : null,
                VehicleCheckListItems = source.VehicleCheckListItems != null ? source.VehicleCheckListItems.Select(mt => mt.CreateFrom()).ToList() : null,
                VehicleImages = source.VehicleImages != null ? source.VehicleImages.Select(mt => mt.CreateFrom()).ToList() : null,
            };
        }



        #endregion

        #region
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleImage CreateFrom(this DomainModels.VehicleImage source)
        {

            return new VehicleImage
            {
                VehicleImageId = source.VehicleImageId,
                Image = source.Image,
            };
        }

        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleImage CreateFrom(this VehicleImage source)
        {
           
            return new DomainModels.VehicleImage
            {
                VehicleImageId = source.VehicleImageId,
                Image = source.Image
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
                       Regions = source.Regions.Select(r => r.CreateDropdownFrom()),
                       FuelTypes = source.FuelTypes.Select(ft => ft.CreateFromDropDown()),
                       VehicleModels = source.VehicleModels.Select(vm => vm.CreateFrom()),
                       VehicleStatuses = source.VehicleStatuses.Select(vs => vs.CreateDropDownFrom()),
                       Departments = source.Departments.Select(d => d.CreateFrom()),
                       VehicleCategories = source.VehicleCategories.Select(vc => vc.CreateFrom()),
                       TransmissionTypes = source.TransmissionTypes.Select(tt => tt.CreateFromDropDown()),
                       VehicleMakes = source.VehicleMakes.Select(vm => vm.CreateFrom()),
                       BusinessPartners = source.BusinessPartners.Select(bp => bp.CreateDropDownModelFrom()),
                       InsuranceType = source.InsuranceType.Select(it => it.CreateFromDropDown()),
                       MaintenanceTypes = source.MaintenanceTypes.Select(mt => mt.CreateFromDropDown()),
                       VehicleCheckList = source.VehicleCheckList.Select(vcl => vcl.CreateFromDropDown()),
                       Locations = source.Locations.Select(loc => loc.CreateFrom())
                   };
        }

        #endregion

        #region Vehicle Other Detail
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleOtherDetail CreateFrom(this VehicleOtherDetail source)
        {
            return new DomainModels.VehicleOtherDetail
            {
                VehicleId = source.VehicleId,
                NumberOfDoors = source.NumberOfDoors,
                HorsePower_CC = source.HorsePower_CC,
                NumberOfCylinders = source.NumberOfCylinders,
                IsAlloyRim = source.IsAlloyRim,
                ChasisNumber = source.ChasisNumber,
                EngineNumber = source.EngineNumber,
                KeyCode = source.KeyCode,
                RadioCode = source.RadioCode,
                Accessories = source.Accessories,
                TopSpeed = source.TopSpeed,
                InteriorDescription = source.InteriorDescription,
                FrontWheelSize = source.FrontWheelSize,
                BackWheelSize = source.BackWheelSize,

            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleOtherDetail CreateFrom(this DomainModels.VehicleOtherDetail source)
        {
            return new VehicleOtherDetail
            {
                VehicleId = source.VehicleId,
                NumberOfDoors = source.NumberOfDoors,
                HorsePower_CC = source.HorsePower_CC,
                NumberOfCylinders = source.NumberOfCylinders,
                IsAlloyRim = source.IsAlloyRim,
                ChasisNumber = source.ChasisNumber,
                EngineNumber = source.EngineNumber,
                KeyCode = source.KeyCode,
                RadioCode = source.RadioCode,
                Accessories = source.Accessories,
                TopSpeed = source.TopSpeed,
                InteriorDescription = source.InteriorDescription,
                FrontWheelSize = source.FrontWheelSize,
                BackWheelSize = source.BackWheelSize,

            };
        }

        #endregion

        #region Vehicle Purchase Info
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehiclePurchaseInfo CreateFrom(this VehiclePurchaseInfo source)
        {
            return new DomainModels.VehiclePurchaseInfo
            {
                VehicleId = source.VehicleId,
                PurchaseDate = source.PurchaseDate,
                PurchaseDescription = source.PurchaseDescription,
                PurchasedFrom = source.PurchasedFrom,
                PurchaseOrderNumber = source.PurchaseOrderNumber,
                PurchaseCost = source.PurchaseCost,
                IsUsedVehicle = source.IsUsedVehicle,

            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehiclePurchaseInfo CreateFrom(this DomainModels.VehiclePurchaseInfo source)
        {
            return new VehiclePurchaseInfo
            {
                VehicleId = source.VehicleId,
                PurchaseDate = source.PurchaseDate,
                PurchaseDescription = source.PurchaseDescription,
                PurchasedFrom = source.PurchasedFrom,
                PurchaseOrderNumber = source.PurchaseOrderNumber,
                PurchaseCost = source.PurchaseCost,
                IsUsedVehicle = source.IsUsedVehicle,
            };
        }

        #endregion

        #region Vehicle Leased Info
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleLeasedInfo CreateFrom(this VehicleLeasedInfo source)
        {
            return new DomainModels.VehicleLeasedInfo
            {
                VehicleId = source.VehicleId,
                DownPayment = source.DownPayment,
                LeasedStartDate = source.LeasedStartDate,
                LeasedFinishDate = source.LeasedFinishDate,
                MonthlyPayment = source.MonthlyPayment,
                LeasedFrom = source.LeasedFrom,
                InterestRate = source.InterestRate,
                PrinicipalPayment = source.PrinicipalPayment,
                FirstPaymentDate = source.FirstPaymentDate,
                LastMonthPayment = source.LastMonthPayment,
                LeaseToOwnership = source.LeaseToOwnership,
                FirstMonthPayment = source.FirstMonthPayment,
                BPMainId = source.BPMainId,


            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleLeasedInfo CreateFrom(this DomainModels.VehicleLeasedInfo source)
        {
            return new VehicleLeasedInfo
            {
                VehicleId = source.VehicleId,
                DownPayment = source.DownPayment,
                LeasedStartDate = source.LeasedStartDate,
                LeasedFinishDate = source.LeasedFinishDate,
                MonthlyPayment = source.MonthlyPayment,
                LeasedFrom = source.LeasedFrom,
                InterestRate = source.InterestRate,
                PrinicipalPayment = source.PrinicipalPayment,
                FirstPaymentDate = source.FirstPaymentDate,
                LeaseToOwnership = source.LeaseToOwnership,
                FirstMonthPayment = source.FirstMonthPayment,
                BPMainId = source.BPMainId,
                LastMonthPayment = source.LastMonthPayment

            };
        }

        #endregion

        #region Vehicle InsuranceI nfo
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleInsuranceInfo CreateFrom(this VehicleInsuranceInfo source)
        {
            return new DomainModels.VehicleInsuranceInfo
            {
                VehicleId = source.VehicleId,
                InsuranceAgent = source.InsuranceAgent,
                CoverageLimit = source.CoverageLimit,
                RenewalDate = source.RenewalDate,
                InsuranceDate = source.InsuranceDate,
                Premium = source.Premium,
                InsuredFrom = source.InsuredFrom,
                BPMainId = source.BPMainId,
                InsuranceTypeId = source.InsuranceTypeId,
                InsuredValue = source.InsuredValue
            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleInsuranceInfo CreateFrom(this DomainModels.VehicleInsuranceInfo source)
        {
            return new VehicleInsuranceInfo
            {
                VehicleId = source.VehicleId,
                InsuranceAgent = source.InsuranceAgent,
                CoverageLimit = source.CoverageLimit,
                RenewalDate = source.RenewalDate,
                InsuranceDate = source.InsuranceDate,
                Premium = source.Premium,
                InsuredFrom = source.InsuredFrom,
                BPMainId = source.BPMainId,
                InsuranceTypeId = source.InsuranceTypeId,
                InsuredValue = source.InsuredValue,


            };
        }

        #endregion

        #region Vehicle Depreciation
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleDepreciation CreateFrom(this VehicleDepreciation source)
        {
            return new DomainModels.VehicleDepreciation
            {
                VehicleId = source.VehicleId,
                UsefulPeriodStartDate = source.UsefulPeriodStartDate,
                FirstMonthDepAmount = source.FirstMonthDepAmount,
                MonthlyDepAmount = source.MonthlyDepAmount,
                LastMonthDepAmount = source.LastMonthDepAmount,
                ResidualValue = source.ResidualValue,
                UsefulPeriodEndDate = source.UsefulPeriodEndDate,

            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleDepreciation CreateFrom(this DomainModels.VehicleDepreciation source)
        {
            return new VehicleDepreciation
            {
                VehicleId = source.VehicleId,
                UsefulPeriodStartDate = source.UsefulPeriodStartDate,
                FirstMonthDepAmount = source.FirstMonthDepAmount,
                MonthlyDepAmount = source.MonthlyDepAmount,
                LastMonthDepAmount = source.LastMonthDepAmount,
                ResidualValue = source.ResidualValue,
                UsefulPeriodEndDate = source.UsefulPeriodEndDate,

            };
        }

        #endregion

        #region Vehicle Disposal Info
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleDisposalInfo CreateFrom(this VehicleDisposalInfo source)
        {
            return new DomainModels.VehicleDisposalInfo
            {
                VehicleId = source.VehicleId,
                SaleDate = source.SaleDate,
                SalePrice = source.SalePrice,
                SoldTo = source.SoldTo,
                DisposalDescription = source.DisposalDescription,
                BPMainId = source.BPMainId
            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleDisposalInfo CreateFrom(this DomainModels.VehicleDisposalInfo source)
        {
            return new VehicleDisposalInfo
            {
                VehicleId = source.VehicleId,
                SaleDate = source.SaleDate,
                SalePrice = source.SalePrice,
                SoldTo = source.SoldTo,
                DisposalDescription = source.DisposalDescription,
                BPMainId = source.BPMainId
            };
        }

        #endregion

        #region Vehicle Maintenance Type Frequency
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleMaintenanceTypeFrequency CreateFrom(this VehicleMaintenanceTypeFrequency source)
        {
            return new DomainModels.VehicleMaintenanceTypeFrequency
            {
                MaintenanceTypeFrequencyId = source.MaintenanceTypeFrequencyId,
                MaintenanceStartDate = source.MaintenanceStartDate,
                Frequency = source.Frequency,
                FrequencyKiloMeter = source.FrequencyKiloMeter,
                MaintenanceTypeId = source.MaintenanceTypeId,
            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleMaintenanceTypeFrequency CreateFrom(this DomainModels.VehicleMaintenanceTypeFrequency source)
        {
            return new VehicleMaintenanceTypeFrequency
            {
                MaintenanceTypeFrequencyId = source.MaintenanceTypeFrequencyId,
                VehicleId = source.VehicleId,
                MaintenanceStartDate = source.MaintenanceStartDate,
                Frequency = source.Frequency,
                FrequencyKiloMeter = source.FrequencyKiloMeter,
                MaintenanceTypeId = source.MaintenanceTypeId,
                MaintenanceTypeCodeName = source.MaintenanceType != null ? source.MaintenanceType.MaintenanceTypeCode + " - " + source.MaintenanceType.MaintenanceTypeName : string.Empty,
            };
        }

        #endregion

        #region Vehicle Check List Item
        /// <summary>
        /// Create entity from web model
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DomainModels.VehicleCheckListItem CreateFrom(this VehicleCheckListItem source)
        {
            return new DomainModels.VehicleCheckListItem
            {
                VehicleCheckListItemId = source.VehicleCheckListItemId,
                VehicleCheckListId = source.VehicleCheckListId,

            };
        }
        /// <summary>
        /// Create web model from Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static VehicleCheckListItem CreateFrom(this DomainModels.VehicleCheckListItem source)
        {
            return new VehicleCheckListItem
            {
                VehicleCheckListItemId = source.VehicleCheckListItemId,
                VehicleId = source.VehicleId,
                VehicleCheckListId = source.VehicleCheckListId,
                VehicleCheckListCodeName = source.VehicleCheckList != null ? source.VehicleCheckList.VehicleCheckListCode + " - " + source.VehicleCheckList.VehicleCheckListName : string.Empty,
            };
        }

        #endregion
    }

}