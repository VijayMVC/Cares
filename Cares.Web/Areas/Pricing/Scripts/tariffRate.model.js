define(["ko", "underscore", "underscore-ko"], function (ko) {

    var
    //Tariff Rate entity
    // ReSharper disable InconsistentNaming
    TariffRate = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            tariffRateId = ko.observable(),
            // Tariff Rate Code 
            tariffRateCode = ko.observable(),
            // Tarrif Type Name
            tariffRateName = ko.observable(),
            //Start From
            startEffectiveDate = ko.observable(),
            //End To
            endEffectiveDate = ko.observable();

        self = {
            tariffRateId: tariffRateId,
            tariffRateCode: tariffRateCode,
            tariffRateName: tariffRateName,
            startEffectiveDate: startEffectiveDate,
            endEffectiveDate: endEffectiveDate,
        };
        return self;
    };
    var TariffRateDetail = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
           // Unique key
            tariffRateId = ko.observable(),
            // Tariff Rate Code 
            tariffRateCode = ko.observable().extend({ required: true }),
            // Tarrif Type Name
            tariffRateName = ko.observable(),
            //Description
            description = ko.observable(),
            //Operation Id
             operationId = ko.observable().extend({ required: true }),
             //Tariff Type Id
             tariffTypeId = ko.observable().extend({ required: true }),
            //Start From
            startEffectiveDate = ko.observable().extend({ required: true }),
            //End To
            endEffectiveDate = ko.observable().extend({ required: true }),
            isBusy = ko.observable(false),
            // Errors
            errors = ko.validation.group({
                tariffRateCode: tariffRateCode,
                operationId: operationId,
                tariffTypeId:tariffTypeId,
                startEffectiveDate: startEffectiveDate,
                endEffectiveDate: endEffectiveDate,
            }),
            // Is Valid
            isValid = ko.computed(function () {
                return errors().length === 0;
            }),
            // True if the booking has been changed
            // ReSharper disable InconsistentNaming
            dirtyFlag = new ko.dirtyFlag({
                tariffRateCode: tariffRateCode,
                tariffRateName: tariffRateName,
                description: description,
                operationId: operationId,
                startEffectiveDate: startEffectiveDate,
                endEffectiveDate: endEffectiveDate,
                tariffTypeId: tariffTypeId,

            }),
            // Has Changes
            hasChanges = ko.computed(function () {
                return dirtyFlag.isDirty();
            }),
            // Reset
            reset = function () {
                dirtyFlag.reset();
            },


        self = {
            tariffRateId: tariffRateId,
            tariffRateCode: tariffRateCode,
            tariffRateName: tariffRateName,
            description: description,
            operationId: operationId,
            tariffTypeId:tariffTypeId,
            startEffectiveDate: startEffectiveDate,
            endEffectiveDate: endEffectiveDate,

            errors: errors,
            isValid: isValid,
            dirtyFlag: dirtyFlag,
            hasChanges: hasChanges,
            reset: reset,
            isBusy: isBusy

        };
        return self;
    };

    //Server To Client Mapper
    var TariffRateClientMapper = function (source) {
        var tariffRate = new TariffRate();
        tariffRate.tariffRateId(source.StandardRtMainId === null ? undefined : source.StandardRtMainId);
        tariffRate.tariffRateCode(source.StandardRtMainCode === null ? undefined : source.StandardRtMainCode);
        tariffRate.tariffRateName(source.StandardRtMainName === null ? undefined : source.StandardRtMainName);
        return tariffRate;
    };

    return {
        TariffRate: TariffRate,
        TariffRateDetail: TariffRateDetail,
        TariffRateClientMapper: TariffRateClientMapper,
    };
});