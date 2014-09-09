/*
    View for the operation. Used to keep the viewmodel clear of UI related logic
*/
define("workLocation/workLocation.view",
    ["jquery", "workLocation/workLocation.viewModel"], function ($, operationViewModel) {
        var ist = window.ist || {};
        // View 
        ist.WorkLocaion.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#WorkPlaceBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OperationsTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getWorkLocations);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(operationViewModel);
        // Initialize the view model
        if (ist.WorkLocaion.view.bindingRoot) {
            operationViewModel.initialize(ist.WorkLocaion.view);
        }
        return ist.WorkLocaion.view;
    });