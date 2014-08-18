/*
    Module with the model for the Insurance Rate
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
        //Insurance Rate entity
        // ReSharper disable InconsistentNaming
     InsuranceRate = function () {
         // ReSharper restore InconsistentNaming
         var // Reference to this object
             self,
             // Unique key

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
        InsuranceRate: InsuranceRate,
    };
});