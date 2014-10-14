/*
    View for the Vehicle Makes Used to keep the viewmodel clear of UI related logic
*/
define("vehicleMake/vehicleMake.view",
    ["jquery", "vehicleMake/vehicleMake.viewModel"], function ($, vehicleMakeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.VehicleMake.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#VehicleMakeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("VehicleMakeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getvehicleMakes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(vehicleMakeViewModel);
        // Initialize the view model
        if (ist.VehicleMake.view.bindingRoot) {
            vehicleMakeViewModel.initialize(ist.VehicleMake.view);
        }
        return ist.VehicleMake.view;
    });