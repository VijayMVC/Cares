/*
    View for the Regions Used to keep the viewmodel clear of UI related logic
*/
define("empStatus/empStatus.view",
    ["jquery", "empStatus/empStatus.viewModel"], function ($, employeeStatusViewModel) {
        var ist = window.ist || {};
        // View 
        ist.EmployeeStatus.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#EmployeeStatusBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getEmployeeStatuses);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(employeeStatusViewModel);
        // Initialize the view model
        if (ist.EmployeeStatus.view.bindingRoot) {
            employeeStatusViewModel.initialize(ist.EmployeeStatus.view);
        }
        return ist.EmployeeStatus.view;
    });