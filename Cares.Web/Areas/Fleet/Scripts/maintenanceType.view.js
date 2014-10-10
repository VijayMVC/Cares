/*
    View for the Maintenance Types Used to keep the viewmodel clear of UI related logic
*/
define("maintenanceType/maintenanceType.view",
    ["jquery", "maintenanceType/maintenanceType.viewModel"], function ($, maintenanceTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.MaintenanceType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#MaintenanceTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("MaintenanceTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getMaintenanceTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(maintenanceTypeViewModel);
        // Initialize the view model
        if (ist.MaintenanceType.view.bindingRoot) {
            maintenanceTypeViewModel.initialize(ist.MaintenanceType.view);
        }
        return ist.MaintenanceType.view;
    });