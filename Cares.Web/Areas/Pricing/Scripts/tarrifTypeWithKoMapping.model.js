define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Tarrif Type entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    TarrifType = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {};

        // Map data to self
        ko.mapping.fromJS(data, null, self);

        // Errors
        self.errors = ko.validation.group({
           // name: self.Name,
         
        }),
        // Is Valid
        self.isValid = ko.computed(function () {
            return self.errors().length === 0;
        }),
        // True if the booking has been changed
        // ReSharper disable InconsistentNaming
        self.dirtyFlag = new ko.dirtyFlag({
            // ReSharper restore InconsistentNaming
            //name: self.Name,
           
        }),
        // Has Changes
        self.hasChanges = ko.computed(function () {
            return self.dirtyFlag.isDirty();
        }),
        // Reset
        self.reset = function () {
            self.dirtyFlag.reset();
        };

        return {
          
            tariffTypeId : self.TariffTypeId,
            tariffTypeCode: self.TariffTypeCode,
            tarrifTypeName: self.TariffTypeName,
            pricingStrategyId: self.PricingStrategyId,
            gracePeriod: self.GracePeriod,
            effectiveDate: self.EffectiveDate,
            durationFrom: self.DurationFrom,
            revisionNumber: self.RevisionNumber,
            durationTo: self.DurationTo,
            hasChanges: self.hasChanges,
            reset: self.reset,
            errors: self.errors,
            isValid: self.isValid
        };
    };

    return {
        TarrifType: TarrifType
    };
});