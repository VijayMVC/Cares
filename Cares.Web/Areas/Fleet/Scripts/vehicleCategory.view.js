/*
    View for the Vehicle Categories Used to keep the viewmodel clear of UI related logic
*/
define("vehicleCategory/vehicleCategory.view",
    ["jquery", "vehicleCategory/vehicleCategory.viewModel"], function ($, vehicleCategoryViewModel) {
        var ist = window.ist || {};
        // View 
        ist.VehicleCategory.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#VehicleCategoryBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("VehicleCategoryTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getVehicleCategories);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(vehicleCategoryViewModel);
        // Initialize the view model
        if (ist.VehicleCategory.view.bindingRoot) {
            vehicleCategoryViewModel.initialize(ist.VehicleCategory.view);
        }
        return ist.VehicleCategory.view;
    });