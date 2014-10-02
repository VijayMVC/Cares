/*
    View for the operation. Used to keep the viewmodel clear of UI related logic
*/
define("workplace/workplace.view",
    ["jquery", "workplace/workplace.viewModel"], function ($, operationViewModel) {
        var ist = window.ist || {};
        // View 
        ist.WorkPlace.view = (function (specifiedViewModel) {
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
                    handleSorting("WorkPlaceTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getWorkPlaces);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(operationViewModel);
        // Initialize the view model
        if (ist.WorkPlace.view.bindingRoot) {
            operationViewModel.initialize(ist.WorkPlace.view);
        }
        return ist.WorkPlace.view;
    });