/*
    Module with the model for the Additional Charge
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
   //Additional Charge Type Entity
    // ReSharper disable once InconsistentNaming
    AdditionalChargeType = function () {
        var // Reference to this object
          self,
          // Unique key
          id = ko.observable(),
          //Code
          code = ko.observable().extend({ required: true }),
          //Name
          name = ko.observable(),
          //Description
          description = ko.observable(),
          //Is Editable
          isEditable = ko.observable(),
          //Additional Charge
          additionalCharge = ko.observable(new AdditionalCharge()),

              // Errors
            errors = ko.validation.group({
                code: code
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),

            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                code: code,
                name: name,
                description: description,
                isEditable: isEditable,
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
            description: description,
            isEditable: isEditable,
            additionalCharge: additionalCharge,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };
    //Additional Charge Entity
    // ReSharper disable once AssignToImplicitGlobalInFunctionScope
    AdditionalCharge = function () {
        var // Reference to this object
          self,
          // Unique key
          id = ko.observable(),
          //Hire Group Id
          hireGroupDetailId = ko.observable().extend({ required: true }),
          //Start Date
          startDate = ko.observable().extend({ required: true }),
          //Rate
          rate = ko.observable().extend({ required: true,number:true }),

              // Errors
            errors = ko.validation.group({
                hireGroupDetailId: hireGroupDetailId,
                startDate: startDate,
                rate: rate,
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
            hireGroupDetailId: hireGroupDetailId,
            startDate: startDate,
            rate: rate,
            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
        };
        return self;
    };

    //Convert Server To Client
    var AdditionalChargeTypeClientMapper = function (source) {
        var addChargeType = new AdditionalChargeType();
        addChargeType.id(source.AdditionalChargeTypeId === null ? undefined : source.AdditionalChargeTypeId);
        addChargeType.code(source.Code === null ? undefined : source.Code);
        addChargeType.name(source.Name === null ? undefined : source.Name);
        addChargeType.description(source.Description === null ? undefined : source.Description);
        addChargeType.isEditable(source.IsEditable === null ? undefined : source.IsEditable);
        return addChargeType;
    };

    var AdditionalDriverChrgServerMapper = function (item) {
        var result = {};
        result.AdditionalDriverChargeId = item.id() === undefined ? 0 : item.id();
        result.TariffTypeCode = item.tariffTypeId() === undefined ? null : item.tariffTypeId();
        result.AdditionalDriverChargeRate = item.rate() === undefined ? null : item.rate();
        result.RevisionNumber = item.revisionNumber() === undefined ? 0 : item.revisionNumber();
        result.StartDt = item.effectiveStartDate() === undefined || item.effectiveStartDate() === null ? null : moment(item.effectiveStartDate()).format(ist.utcFormat);
        return result;
    };
    // Convert Client to server
    var AdditionalChrgServerMapperForId = function (source) {
        var result = {};
        result.AdditionalChargeTypeId = source.id() === undefined ? 0 : source.id();
        return result;
    };
    return {
        AdditionalChargeType: AdditionalChargeType,
        AdditionalCharge: AdditionalCharge,
        AdditionalChargeTypeClientMapper: AdditionalChargeTypeClientMapper,
        AdditionalChrgServerMapperForId: AdditionalChrgServerMapperForId,
    };
});