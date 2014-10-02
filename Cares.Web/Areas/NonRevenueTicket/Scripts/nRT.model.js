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
    //Non Revenue Ticket Main Entity
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

    return {
        NRTMain: NRTMain,
        VehicleDetail: VehicleDetail,
    };
});