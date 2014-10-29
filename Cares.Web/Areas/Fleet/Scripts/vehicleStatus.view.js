/*
    View for the Vehicle Status Used to keep the viewmodel clear of UI related logic
*/
define("vehicleStatus/vehicleStatus.view",
    ["jquery", "vehicleStatus/vehicleStatus.viewModel"], function ($, vehicleStatusViewModel) {
        var ist = window.ist || {};
        // View 
        ist.VehicleStatus.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#VehicleStatusBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("VehicleStatusTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getVehiclStatuses);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(vehicleStatusViewModel);
        // Initialize the view model
        if (ist.VehicleStatus.view.bindingRoot) {
            vehicleStatusViewModel.initialize(ist.VehicleStatus.view);
        }
        return ist.VehicleStatus.view;
    });