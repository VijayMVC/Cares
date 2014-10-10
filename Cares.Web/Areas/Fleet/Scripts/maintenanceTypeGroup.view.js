/*
    View for the  Maintenance Type Group Used to keep the viewmodel clear of UI related logic
*/
define("maintenanceTypeGroup/maintenanceTypeGroup.view",
    ["jquery", "maintenanceTypeGroup/maintenanceTypeGroup.viewModel"], function ($, maintenanceTypeGroupViewModel) {
        var ist = window.ist || {};
        // View 
        ist.MaintenanceTypeGroup.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#MaintenanceTypeGroupBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("MaintenanceTypeGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getMaintenanceTypeGroups);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(maintenanceTypeGroupViewModel);
        // Initialize the view model
        if (ist.MaintenanceTypeGroup.view.bindingRoot) {
            maintenanceTypeGroupViewModel.initialize(ist.MaintenanceTypeGroup.view);
        }
        return ist.MaintenanceTypeGroup.view;
    });