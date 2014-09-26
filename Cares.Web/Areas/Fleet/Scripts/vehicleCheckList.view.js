/*
    View for the Vehicle CheckList Used to keep the viewmodel clear of UI related logic
*/
define("vehicleCheckList/vehicleCheckList.view",
    ["jquery", "vehicleCheckList/vehicleCheckList.viewModel"], function ($, vehicleCheckListViewModel) {
        var ist = window.ist || {};
        // View 
        ist.VehicleCheckList.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#VehicleCheckListBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getVehicleCheckLists);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(vehicleCheckListViewModel);
        // Initialize the view model
        if (ist.VehicleCheckList.view.bindingRoot) {
            vehicleCheckListViewModel.initialize(ist.VehicleCheckList.view);
        }
        return ist.VehicleCheckList.view;
    });