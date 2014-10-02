/*
    View for the Occupation Type Used to keep the viewmodel clear of UI related logic
*/
define("occupationType/occupationType.view",
    ["jquery", "occupationType/occupationType.viewModel"], function ($, occupationTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.OccupationType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#OccupationTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OccupationTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getOccupationTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(occupationTypeViewModel);
        // Initialize the view model
        if (ist.OccupationType.view.bindingRoot) {
            occupationTypeViewModel.initialize(ist.OccupationType.view);
        }
        return ist.OccupationType.view;
    });