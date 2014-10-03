/*
    Module with the model for the Non Revenue Ticket
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Non Revenue Ticket Main Entity
    // ReSharper disable once InconsistentNaming
    NRTMain = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Operation ID
            operationId = ko.observable().extend({ required: true }),
            //Out Location Id
            outLocationId = ko.observable().extend({ required: true }),
            //Return Location Id
            retLocationId = ko.observable().extend({ required: true }),
            //Start Date
            startDate = ko.observable(new Date).extend({ required: true }),
            //End Date
            endDate = ko.observable().extend({ required: true }),
            //NRT Type ID
            nRtTypeId = ko.observable().extend({ required: true }),
            //Vehicle Detail In NRT Main
            vehicleDetail = ko.observable(new VehicleDetail()),
            // Errors
            errors = ko.validation.group({
                operationId: operationId,
                outLocationId: outLocationId,
                retLocationId: retLocationId,
                startDate: startDate,
                endDate: endDate,
                nRtTypeId: nRtTypeId,
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
            id: id,
            operationId: operationId,
            outLocationId: outLocationId,
            retLocationId: retLocationId,
            startDate: startDate,
            endDate: endDate,
            nRtTypeId: nRtTypeId,
            vehicleDetail: vehicleDetail,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Vehicle Detail In Revenue TicketEntity
    // ReSharper disable once InconsistentNaming
    var VehicleDetail = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //vehicle ID
            vehicleId = ko.observable(),
            //Plate Number
            plateNum = ko.observable(),
            //Is Return Location
            isReturnLoc = ko.observable(),
            //Out Date Time
            outDtTime = ko.observable().extend({ required: true }),
            //In date Time
            indDtTime = ko.observable().extend({ required: true }),
            //Out Location
            outLocId = ko.observable().extend({ required: true }),
             //In Location
            inLocId = ko.observable().extend({ required: true }),
            //Out Odemetor
            outOdemeter = ko.observable().extend({ required: true }),
            //In Odemeter
            inOdemeter = ko.observable().extend({ required: true }),
            //Fuel In
            fuelIn = ko.observable().extend({ required: true }),
            //Fuel Out
            fuelOut = ko.observable().extend({ required: true }),
            //Fuel Difference
            fuelDiff = ko.observable(),
            //Condition In
            conditionIn = ko.observable().extend({ required: true }),
            //Condition Out
            conditionOut = ko.observable().extend({ required: true }),
            //vehicle In Status Id
            vInStatusId = ko.observable().extend({ required: true }),
            //Vehicle Out Status Id
            vOutStatusId = ko.observable().extend({ required: true }),

              // Errors
            errors = ko.validation.group({
                outDtTime: outDtTime,
                indDtTime: indDtTime,
                outLocId: outLocId,
                inLocId: inLocId,
                outOdemeter: outOdemeter,
                inOdemeter: inOdemeter,
                fuelIn: fuelIn,
                fuelOut: fuelOut,
                vInStatusId: vInStatusId,
                vOutStatusId: vOutStatusId,
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
            id: id,
            vehicleId: vehicleId,
            plateNum: plateNum,
            isReturnLoc: isReturnLoc,
            outDtTime: outDtTime,
            indDtTime: indDtTime,
            outLocId: outLocId,
            inLocId: inLocId,
            outOdemeter: outOdemeter,
            inOdemeter: inOdemeter,
            fuelIn: fuelIn,
            fuelOut: fuelOut,
            fuelDiff: fuelDiff,
            conditionIn: conditionIn,
            conditionOut: conditionOut,
            vInStatusId: vInStatusId,
            vOutStatusId: vOutStatusId,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Maintenance Activity In Non Revenue Ticket Entity
    // ReSharper disable once InconsistentNaming
    var MaintenanceActivity = function () {
        var // Reference to this object
            self,
            // Unique key
            id = ko.observable(),
            //Additional Charge Type Code
            code = ko.observable(),
            //Additional Charge Type Name
            name = ko.observable(),
            //Quantity
            qty = ko.observable().extend({ required: true }),
            //Total Rate
            totalRate = ko.observable(),
            //Contact Person
            contactPerson = ko.observable(),
            //Description
            description = ko.observable(),
             //Rate
            rate = ko.observable(),
            // Errors
            errors = ko.validation.group({
                qty: qty
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
            id: id,
            code: code,
            name: name,
            qty: qty,
            totalRate: totalRate,
            contactPerson: contactPerson,
            description: description,
            rate: rate,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Vehicle List View entity
    // ReSharper disable once InconsistentNaming
    var Vehicle = function () {
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
            //
            vehicleModelCodeName = ko.observable(),
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
            vehicleModelCodeName: vehicleModelCodeName,
            location: location
        };
        return self;
    };
    //Convert Server To Client
    var VehicleDetailClientMapper = function (source) {
        var vehicle = new Vehicle();
        vehicle.vehicleId(source.VehicleId === null ? undefined : source.VehicleId);
        vehicle.vehicleMakeCodeName(source.VehicleMakeCodeName === null ? undefined : source.VehicleMakeCodeName);
        vehicle.vehicleModelCodeName(source.OperationCodeName === null ? undefined : source.OperationCodeName);
        return vehicle;
    };
    return {
        NRTMain: NRTMain,
        Vehicle: Vehicle,
        VehicleDetail: VehicleDetail,
        MaintenanceActivity: MaintenanceActivity,
        VehicleDetailClientMapper: VehicleDetailClientMapper,
    };
});