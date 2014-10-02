/*
    View for the designations Used to keep the viewmodel clear of UI related logic
*/
define("designation/designation.view",
    ["jquery", "designation/designation.viewModel"], function ($, designationViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Designation.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#DesignationBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("DesignationTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDesignations);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(designationViewModel);
        // Initialize the view model
        if (ist.Designation.view.bindingRoot) {
            designationViewModel.initialize(ist.Designation.view);
        }
        return ist.Designation.view;
    });