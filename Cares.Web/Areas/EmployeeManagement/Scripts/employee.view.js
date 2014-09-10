/*
    View for the Employee. Used to keep the viewmodel clear of UI related logic
*/
define("employee/employee.view",
    ["jquery", "employee/employee.viewModel"], function ($, employeeViewModel) {

        var ist = window.ist || {};

        // View 
        ist.employee.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#employeeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("employeeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getEmployees);

                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(employeeViewModel);

        // Initialize the view model
        if (ist.employee.view.bindingRoot) {
            employeeViewModel.initialize(ist.employee.view);
        }
        return ist.employee.view;
    });