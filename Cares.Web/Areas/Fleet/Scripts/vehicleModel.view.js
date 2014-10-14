/*
    View for the Vehicle Models Used to keep the viewmodel clear of UI related logic
*/
define("vehicleModel/vehicleModel.view",
    ["jquery", "vehicleModel/vehicleModel.viewModel"], function ($, vehicleModelViewModel) {
        var ist = window.ist || {};
        // View 
        ist.VehicleModel.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#VehicleModelBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("VehicleModelTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getVehicleModels);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(vehicleModelViewModel);
        // Initialize the view model
        if (ist.VehicleModel.view.bindingRoot) {
            vehicleModelViewModel.initialize(ist.VehicleModel.view);
        }
        return ist.VehicleModel.view;
    });