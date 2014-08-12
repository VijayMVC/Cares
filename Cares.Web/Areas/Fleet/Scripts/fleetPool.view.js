/*
    View for the Product. Used to keep the viewmodel clear of UI related logic
*/
define("Fleet/fleetPool.view",
    ["jquery", "Fleet/fleetPool.viewModel"], function ($, fleetPoolViewModel) {

        var ist = window.ist || {};

        // View 
        ist.fleetPool.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#fleetRootBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }

                    // Handle Sorting
                    handleSorting("fleetPoolTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getFleetPools);
                };

            initialize();


            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(fleetPoolViewModel);

        // Initialize the view model
        if (ist.fleetPool.view.bindingRoot) {
            fleetPoolViewModel.initialize(ist.fleetPool.view);
        }

        return ist.fleetPool.view;
    });