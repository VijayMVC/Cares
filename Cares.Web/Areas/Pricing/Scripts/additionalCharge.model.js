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
            isEditable = ko.observable(true),
            //Additional Charge
            additionalCharge = ko.observable(new AdditionalCharge()),
            //Additional Charges List
            additionalChargesList = ko.observableArray([]),
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
            additionalChargesList: additionalChargesList,
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
          hireGroupDetailId = ko.observable(),
          //Hire Group Code Name
          hireGroupDetailCodeName = ko.observable(),
          //Start Date
          startDate = ko.observable().extend({ required: true }),
          //Rate
          rate = ko.observable().extend({ required: true, number: true }),
          //Revision Number
          revisionNumber = ko.observable().extend({ required: true, number: true }),
           //String valued formatted date
            formattedStartDate = ko.computed({
                read: function () {
                    return moment(startDate()).format(ist.datePattern);
                }
            }),
              // Errors
            errors = ko.validation.group({
                //hireGroupDetailId: hireGroupDetailId,
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
            hireGroupDetailCodeName: hireGroupDetailCodeName,
            startDate: startDate,
            formattedStartDate: formattedStartDate,
            revisionNumber: revisionNumber,
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

    //Convert Server To Client
    var AdditionalChargeClientMapper = function (source) {
        var addCharge = new AdditionalCharge();
        addCharge.id(source.AdditionalChargeId === null ? undefined : source.AdditionalChargeId);
        addCharge.hireGroupDetailCodeName(source.HireGroupDetailCodeName === null ? undefined : source.HireGroupDetailCodeName);
        addCharge.hireGroupDetailId(source.HireGroupDetailId === null ? undefined : source.HireGroupDetailId);
        addCharge.revisionNumber(source.RevisionNumber === null ? undefined : source.RevisionNumber);
        addCharge.rate(source.AdditionalChargeRate === null ? undefined : source.AdditionalChargeRate);
        addCharge.startDate(source.StartDt !== null ? moment(source.StartDt, ist.utcFormat).toDate() : undefined);
        return addCharge;
    };
    //Convert Client To Server
    var AdditionalChargeTypeServerMapper = function (source) {
        var result = {};
        result.AdditionalChargeTypeId = source.id() === undefined ? 0 : source.id();
        result.Code = source.code() === undefined ? null : source.code();
        result.Name = source.name() === undefined ? null : source.name();
        result.Description = source.description() === undefined ? 0 : source.description();
        result.IsEditable = source.isEditable() === undefined ? 0 : source.isEditable();
        result.AdditionalCharges = [];
        _.each(source.additionalChargesList(), function (item) {
            result.AdditionalCharges.push(AdditionalChargeServerMapper(item));
        });

        return result;
    };
    //Convert Client To Server
    var AdditionalChargeServerMapper = function (item) {
        var result = {};
        result.AdditionalChargeId = item.id() === undefined ? 0 : item.id();
        result.HireGroupDetailId = item.hireGroupDetailId() === undefined ? null : item.hireGroupDetailId();
        result.AdditionalChargeRate = item.rate() === undefined ? null : item.rate();
        result.revisionNumber = item.rate() === undefined ? null : item.rate();
        result.StartDt = item.startDate() === undefined || item.startDate() === null ? null : moment(item.startDate()).format(ist.utcFormat);
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
        AdditionalChargeTypeServerMapper: AdditionalChargeTypeServerMapper,
        AdditionalChargeServerMapper: AdditionalChargeServerMapper,
        AdditionalChrgServerMapperForId: AdditionalChrgServerMapperForId,
        AdditionalChargeClientMapper: AdditionalChargeClientMapper,
    };
});