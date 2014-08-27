/*
    View for the department. Used to keep the viewmodel clear of UI related logic
*/
define("department/department.view",
    ["jquery", "department/department.viewModel"], function ($, departmentViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Department.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#OperationBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OperationsTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDepartments);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(departmentViewModel);
        // Initialize the view model
        if (ist.Department.view.bindingRoot) {
            departmentViewModel.initialize(ist.Department.view);
        }
        return ist.Department.view;
    });