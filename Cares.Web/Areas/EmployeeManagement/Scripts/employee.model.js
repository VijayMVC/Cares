/*
    Module with the model for the Employee
*/
define(["ko", "underscore", "underscore-ko"], function (ko) {
    var
     //Employee List View entity
    // ReSharper disable once InconsistentNaming
    Employee = function () {
        // ReSharper restore InconsistentNaming
        var // Reference to this object
            self,
            // Unique key
            employeeId = ko.observable();


        self = {
            employeeId: employeeId,

        };
        return self;
    };

    return {
        Employee: Employee,

    };
});