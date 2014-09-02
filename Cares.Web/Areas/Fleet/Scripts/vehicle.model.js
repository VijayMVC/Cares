/*
    Module with the model for the Vehicle
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
     //Vehicle List View entity
    // ReSharper disable once InconsistentNaming
    Vehicle = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(),
            //  Vehicle Name
            vehicleName = ko.observable(),
            //plate Number
            plateNumber = ko.observable(),
            //Current Odometer
            currentOdometer = ko.observable(),
            //Fuel Level
            fuelLevel = ko.observable(),
            //Model Year
            modelYear = ko.observable(),
            //Vehicle Make Code Name
            vehicleMakeCodeName = ko.observable(),
            //Vehicle Status Code Name
            vehicleStatusCodeName = ko.observable(),
            //Fleet Pool Code Name
            fleetPoolCodeName = ko.observable(),
            //Operation Code NAme
            operationCodeName = ko.observable(),
            //Location
            location = ko.observable();

        self = {
            vehicleId: vehicleId,
            vehicleName: vehicleName,
            plateNumber: plateNumber,
            currentOdometer: currentOdometer,
            fuelLevel: fuelLevel,
            modelYear: modelYear,
            vehicleMakeCodeName: vehicleMakeCodeName,
            vehicleStatusCodeName: vehicleStatusCodeName,
            fleetPoolCodeName: fleetPoolCodeName,
            operationCodeName: operationCodeName,
            location: location
        };
        return self;
    };
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    VehicleDetail = function (specifiedKey, specifiedVehicleName, specifiedPNumber, specifiedCompanyId, specifiedDepartmentId, specifiedOperationId, specifiedRegionId,
        specifiedFleetPoolId, specifiedLocationId, specifiedFuelTypeId, specifiedFuelLevel, specifiedVehicleMakeId,
        specifiedVehicleModelId, specifiedVehicleCategoryId, specifiedModelYear, specifiedStatusId, specifiedTransmissionTypeId, specifiedTankSize, specifiedColor,
        specifiedInitialOdemeter, specifiedCurrentOdemeter, specifiedBranchOwnerIsChecked, specifiedRegistrationDate, specifiedRegistrationExpDate) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(specifiedKey),
            //Vehicle Name
            vehicleName = ko.observable(specifiedVehicleName),
            //plate Number
            plateNumber = ko.observable(specifiedPNumber).extend({ required: true }),
            //Company ID
            companyId = ko.observable(specifiedCompanyId),
            //Department Id
            departmentId = ko.observable(specifiedDepartmentId),
            //Operation Id
            operationId = ko.observable(specifiedOperationId),
             //Region Id
            regionId = ko.observable(specifiedRegionId),
            //Fleet Pool Id
            fleetPoolId = ko.observable(specifiedFleetPoolId),
            //Location Id
            locationId = ko.observable(specifiedLocationId),
            //Fuel Type Id
            fuelTypeId = ko.observable(specifiedFuelTypeId).extend({ required: true }),
            //Fuel Level
            fuelLevel = ko.observable(specifiedFuelLevel),
            //Vehicle Make ID
            vehicleMakeId = ko.observable(specifiedVehicleMakeId).extend({ required: true }),
            //Vehicle Model ID
            vehicleModelId = ko.observable(specifiedVehicleModelId).extend({ required: true }),
            //Vehicle Category ID
            vehicleCategoryId = ko.observable(specifiedVehicleCategoryId).extend({ required: true }),
            //Model Year
            modelYear = ko.observable(specifiedModelYear).extend({ required: true }),
            //Status Id
            statusId = ko.observable(specifiedStatusId).extend({ required: true }),
            //Transmission ID
            transmissionTypeId = ko.observable(specifiedTransmissionTypeId).extend({ required: true }),
            //Tank Size
            tankSize = ko.observable(specifiedTankSize).extend({ required: true }),
            //Color
            color = ko.observable(specifiedColor).extend({ required: true }),
            //Initial Odementer
            initialOdemeter = ko.observable(specifiedInitialOdemeter).extend({ required: true }),
            //Current Odemeter
            currentOdemeter = ko.observable(specifiedCurrentOdemeter).extend({ required: true }),
            //Branch Owner
            branchOwnerIsChecked = ko.observable(specifiedBranchOwnerIsChecked).extend({ required: true }),
            //Registration Date
            registrationDate = ko.observable(specifiedRegistrationDate),
            //Registration Exp. Date
            registrationExpDate = ko.observable(specifiedRegistrationExpDate),

            // Errors
            errors = ko.validation.group({
                plateNumber: plateNumber,
                fuelTypeId: fuelTypeId,
                vehicleMakeId: vehicleMakeId,
                vehicleModelId: vehicleModelId,
                modelYear: modelYear,
                statusId: statusId,
                vehicleCategoryId: vehicleCategoryId,
                transmissionTypeId: transmissionTypeId,
                color: color,
                initialOdemeter: initialOdemeter,
                currentOdemeter: currentOdemeter,
                tankSize: tankSize,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
             // Convert to server
            convertToServerData = function () {
                return {
                    VehicleId: vehicleId(),
                };
            },
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                vehicleName: vehicleName,
                plateNumber: plateNumber,
                companyId: companyId,
                departmentId: departmentId,
                operationId: operationId,
                regionId: regionId,
                fleetPoolId: fleetPoolId,
                locationId: locationId,
                fuelTypeId: fuelTypeId,
                fuelLevel: fuelLevel,
                vehicleMakeId: vehicleMakeId,
                vehicleModelId: vehicleModelId,
                vehicleCategoryId: vehicleCategoryId,
                statusId: statusId,
                transmissionTypeId: transmissionTypeId,
                tankSize: tankSize,
                color: color,
                initialOdemeter: initialOdemeter,
                currentOdemeter: currentOdemeter,
                branchOwnerIsChecked: branchOwnerIsChecked,
                registrationDate: registrationDate,
                registrationExpDate: registrationExpDate,
                modelYear: modelYear,
            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            vehicleId: vehicleId,
            vehicleName: vehicleName,
            plateNumber: plateNumber,
            companyId: companyId,
            departmentId: departmentId,
            operationId: operationId,
            regionId: regionId,
            fleetPoolId: fleetPoolId,
            locationId: locationId,
            fuelTypeId: fuelTypeId,
            fuelLevel: fuelLevel,
            vehicleMakeId: vehicleMakeId,
            vehicleModelId: vehicleModelId,
            vehicleCategoryId: vehicleCategoryId,
            statusId: statusId,
            transmissionTypeId: transmissionTypeId,
            tankSize: tankSize,
            color: color,
            initialOdemeter: initialOdemeter,
            currentOdemeter: currentOdemeter,
            branchOwnerIsChecked: branchOwnerIsChecked,
            registrationDate: registrationDate,
            registrationExpDate: registrationExpDate,
            modelYear: modelYear,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            convertToServerData: convertToServerData,


        };
        return self;
    };
    //Other Vehicle Detail Entity
    // ReSharper disable once InconsistentNaming
    var OtherVehicleDetail = function () {
        var // Reference to this object
          self,
          // Unique key
          otherVehicleDetailId = ko.observable(),
          //Number Of Doors
          numberOfDoors = ko.observable(),
          //Engine CC
          horsePowerCc = ko.observable(),
          //Number Of Cylinders
          numberOfCylinders = ko.observable(),
          //is Alloy Rim
          isAlloyRim = ko.observable(),
          //Chasis Number
          chasisNumber = ko.observable().extend({ required: true }),
          //Engine Number
          engineNumber = ko.observable().extend({ required: true }),
          //Key Code
          keyCode = ko.observable(),
          //Radio Code
          radioCode = ko.observable(),
          //Accessories
          accessories = ko.observable(),
          //Top Speed
          topSpeed = ko.observable(),
          //Interior Description
          interiorDescription = ko.observable(),
          //Front Wheel Size
          frontWheelSize = ko.observable(),
          //Back Wheel Size
          backWheelSize = ko.observable(),
          

            // Errors
            errors = ko.validation.group({
                chasisNumber: chasisNumber,
                engineNumber: engineNumber
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Purchase Info Entity
    // ReSharper disable once InconsistentNaming
    var PurchaseInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          purchaseInfoId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Leased Info Entity
    // ReSharper disable once InconsistentNaming
    var LeasedInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          leasedInfoId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Insurance Info Entity
    // ReSharper disable once InconsistentNaming
    var InsuranceInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          insuranceInfoId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Maintenance Schedule Entity
    // ReSharper disable once InconsistentNaming
    var MaintenanceSchedule = function () {
        var // Reference to this object
          self,
          // Unique key
          maintenanceScheduleId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Check List Item Entity
    // ReSharper disable once InconsistentNaming
    var CheckListItem = function () {
        var // Reference to this object
          self,
          // Unique key
          checkListItemId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Depriciation Info Entity
    // ReSharper disable once InconsistentNaming
    var DepriciationInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          depriciationInfoId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Disposal Info Entity
    // ReSharper disable once InconsistentNaming
    var DisposalInfo = function () {
        var // Reference to this object
          self,
          // Unique key
          disposalInfoId = ko.observable(),
            // Errors
            errors = ko.validation.group({

            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            };

        self = {
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    // Convert (Vehicle Detail) Client to server
    var VehicleDetailServerMapper = function (source) {
        var result = {};
        // Main top section
        result.VehicleId = source.vehicleId();
        result.vehicleName = source.vehicleName();
        result.PlateNumber = source.plateNumber();
        result.OperationId = source.operationId();
        result.regionId = source.regionId();
        result.FleetPoolId = source.fleetPoolId();
        result.FuelTypeId = source.fuelTypeId();
        result.OperationsWorkPlaceId = source.locationId();
        result.FuelLevel = source.fuelLevel();
        result.VehicleMakeId = source.vehicleMakeId();
        result.VehicleModelId = source.vehicleModelId();
        result.VehicleCategoryId = source.vehicleCategoryId();
        result.VehicleStatusId = source.statusId();
        result.TransmissionTypeId = source.transmissionTypeId();
        result.TankSize = source.tankSize();
        result.Color = source.color();
        result.InitialOdometer = source.initialOdemeter();
        result.CurrentOdometer = source.currentOdemeter();
        result.IsBranchOwner = source.branchOwnerIsChecked();
        result.RegistrationDate = result.EndDt = source.registrationDate() === undefined || source.registrationDate() === null ? undefined : moment(source.registrationDate()).format(ist.utcFormat);
        result.RegistrationExpiryDate = result.EndDt = source.registrationExpDate() === undefined || source.registrationExpDate() === null ? undefined : moment(source.registrationExpDate()).format(ist.utcFormat);
        result.ModelYear = source.modelYear();

        return result;
    };
    // Convert (Vehicle Detail) Client to server
    var VehicleDetailServerMappeForDelete = function (source) {
        var result = {};
        // Main top section
        result.VehicleId = source.vehicleId();
        return result;
    };
    // Vehicle Detail Factory
    VehicleDetail.Create = function () {
        return new VehicleDetail(0, "", "", undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined, undefined,
        undefined, undefined, undefined, undefined, "", "", undefined, true, undefined, undefined);
    };
    // ReSharper disable once InconsistentNaming
    var VehicleClientMapper = function (source) {
        var vehicle = new Vehicle();
        vehicle.vehicleId(source.VehicleId === null ? undefined : source.VehicleId);
        vehicle.vehicleName(source.VehicleName === null ? undefined : source.VehicleName);
        vehicle.plateNumber(source.PlateNumber === null ? undefined : source.PlateNumber);
        vehicle.currentOdometer(source.CurrentOdometer === null ? undefined : source.CurrentOdometer);
        vehicle.modelYear(source.ModelYear === null ? undefined : source.ModelYear);
        vehicle.vehicleMakeCodeName(source.VehicleMakeCodeName === null ? undefined : source.VehicleMakeCodeName);
        vehicle.vehicleStatusCodeName(source.VehicleStatusCodeName === null ? undefined : source.VehicleStatusCodeName);
        vehicle.fleetPoolCodeName(source.FleetPoolCodeName === null ? undefined : source.FleetPoolCodeName);
        vehicle.operationCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        vehicle.location(source.Location === null ? undefined : source.Location);
        vehicle.fuelLevel(source.FuelLevel === null ? undefined : source.FuelLevel);
        return vehicle;
    };
    return {
        Vehicle: Vehicle,
        VehicleClientMapper: VehicleClientMapper,
        VehicleDetail: VehicleDetail,
        VehicleDetailServerMapper: VehicleDetailServerMapper,
        VehicleDetailServerMappeForDelete: VehicleDetailServerMappeForDelete,
        OtherVehicleDetail: OtherVehicleDetail,
        PurchaseInfo: PurchaseInfo,
        LeasedInfo: LeasedInfo,
        InsuranceInfo: InsuranceInfo,
        MaintenanceSchedule: MaintenanceSchedule,
        CheckListItem: CheckListItem,
        DepriciationInfo: DepriciationInfo,
        DisposalInfo: DisposalInfo
    };
});