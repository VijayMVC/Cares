/*
    Module with the model for the Service Rate
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //Service Main Rate entity
        // ReSharper disable InconsistentNaming
     ServiceRtMain = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key
             serviceRtMainId = ko.observable(),
             //Service Rate Main Code
             serviceRtMainCode = ko.observable().extend({ required: true }),
             //Service Rate Name
             serviceRtName = ko.observable(),
             //Description
             description = ko.observable(),
             //Tariff Type Code Name
             tariffTypeCodeName = ko.observable(),
             //Tariff Type Id
             tariffTypeId = ko.observable().extend({ required: true }),
             //Start Date
             startDt = ko.observable().extend({ required: true }),
             //Operation Id
             operationId = ko.observable().extend({ required: true }),
             //Operation Code Name
             operationCodeName = ko.observable(),
              //Service Rate In Service Rate Main
             serviceItemRts = ko.observableArray([]),
              // Formatted Start Date for grid
             formattedStartDate = ko.computed({
                 read: function () {
                     return moment(startDt()).format(ist.datePattern);
                 }
             }),
             // Errors
             errors = ko.validation.group({
                 insuranceRtMainCode: insuranceRtMainCode,
                 tariffTypeId: tariffTypeId,
                 startDt: startDt,
                 operationId: operationId
             }),
             // Is Valid
             isValid = ko.computed(function () {
                 return errors().length === 0;
             }),
              // Convert to server
             convertToServerData = function () {
                 return {
                     serviceRtMainId: serviceRtMainId(),
                 };
             },
             // True if the booking has been changed
             // ReSharper disable InconsistentNaming
             dirtyFlag = new ko.dirtyFlag({
                 insuranceRtMainCode: insuranceRtMainCode,
                 insuranceRtName: insuranceRtName,
                 description: description,
                 tariffTypeId: tariffTypeId,
                 startDt: startDt,
                 operationId: operationId
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
             insuranceRtMainId: insuranceRtMainId,
             insuranceRtMainCode: insuranceRtMainCode,
             insuranceRtName: insuranceRtName,
             description: description,
             tariffTypeId: tariffTypeId,
             startDt: startDt,
             operationId: operationId,
             tariffTypeCodeName: tariffTypeCodeName,
             operationCodeName: operationCodeName,
             formattedStartDate: formattedStartDate,
             insuranceRts: insuranceRts,
             errors: errors,
             isValid: isValid,
             dirtyFlag: dirtyFlag,
             hasChanges: hasChanges,
             reset: reset,
             convertToServerData: convertToServerData,


         };
         return self;
     };
     // ReSharper disable once AssignToImplicitGlobalInFunctionScope
     ServiceItemRt = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,


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

    return {
        ServiceRtMain: ServiceRtMain,
        ServiceItemRt: ServiceItemRt,
    };
});