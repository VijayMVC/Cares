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
    VehicleDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            vehicleId = ko.observable(),
            //Vehicle Name
            vehicleName = ko.observable(),
            //plate Number
            plateNumber = ko.observable().extend({ required: true }),
            //Company ID
            companyId = ko.observable(),
            //Department Id
            departmentId = ko.observable(),
            //Operation Id
            operationId = ko.observable(),
             //Region Id
            regionId = ko.observable(),
            //Fleet Pool Id
            fleetPoolId = ko.observable(),
            //Location Id
            locationId = ko.observable(),
            //Fuel Type Id
            fuelTypeId = ko.observable().extend({ required: true }),
            //Fuel Level
            fuelLevel = ko.observable(),
            //Vehicle Make ID
            vehicleMakeId = ko.observable().extend({ required: true }),
            //Vehicle Model ID
            vehicleModelId = ko.observable().extend({ required: true }),
            //Vehicle Category ID
            vehicleCategoryId = ko.observable().extend({ required: true }),
            //Model Year
            modelYear = ko.observable().extend({ required: true }),
            //Status Id
            statusId = ko.observable().extend({ required: true }),
            //Transmission ID
            transmissionTypeId = ko.observable().extend({ required: true }),
            //Tank Size
            tankSize = ko.observable().extend({ required: true }),
            //Color
            color = ko.observable().extend({ required: true }),
            //Initial Odementer
            initialOdemeter = ko.observable().extend({ required: true }),
            //Current Odemeter
            currentOdemeter = ko.observable().extend({ required: true }),
            //Branch Owner
            branchOwnerIsChecked = ko.observable().extend({ required: true }),
            //Registration Date
            registrationDate = ko.observable(),
            //Registration Exp. Date
            registrationExpDate = ko.observable(),

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
                    vehicleId: vehicleId(),
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
        VehicleDetail: VehicleDetail
    };
});