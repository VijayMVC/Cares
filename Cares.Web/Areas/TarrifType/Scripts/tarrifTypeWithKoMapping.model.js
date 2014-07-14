define(["ko", "underscore", "underscore-ko"], function (ko) {

    var

    // Tarrif Type entity - Using Knockout Mapping
    // ReSharper disable InconsistentNaming
    TarrifType = function (data) {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self = {};
           
        // Map data to self
        ko.mapping.fromJS(data,self);

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
                categoryId: self.CategoryId,
            categoryName: self.categoryName,
            assignCategories: self.assignCategories,
            categories: self.categories,
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