define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Tarrif Type entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    TarrifType = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {},
        mapping = {
            // customize the creation of the name property so that it provides validation
            TariffTypeId: {
                create: function (options) {
                    return ko.observable(options.data).extend({ required: true });
                }
            },
            OperationId: {
                create: function (options) {
                    return ko.observable(options.data).extend({ required: true });
                }
            },
            MeasurementUnitId: {
                create: function (options) {
                    return ko.observable(options.data).extend({ required: true });
                }
            }
        };

        // Map data to self
        ko.mapping.fromJS(data, mapping,self);

        // Extend Product
        // Categoreis
        self.categories = ko.observableArray([]),
        // Category Name
        self.categoryName = ko.computed(function () {
            if (!self.CategoryId()) {
                return "";
            }
            var categoryResult = self.categories.find(function (category) {
                return category.Id === self.CategoryId();
            });

            return categoryResult ? categoryResult.Name : "";
        }),
      
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
            tarrifTypeId: TariffTypeId,
            //userDomainKey: userDomainKey,
            operationId: OperationId,
            measurementUnitId: MeasurementUnitId,
           // categories: self.categories,
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