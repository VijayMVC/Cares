/*
    View for the tariff Type. Used to keep the viewmodel clear of UI related logic
*/
define("nRT/nRT.view",
    ["jquery", "nRT/nRT.viewModel"], function ($, nRTViewModel) {

        var ist = window.ist || {};

        // View 
        ist.nRT.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#nRTBinding")[0],
                 // Show the dialog
                show = function () {
                    $("#dialog-vehicleDetailDialog").modal("show");
                },
                // Hide the dialog
                hide = function () {
                    $("#dialog-vehicleDetailDialog").modal("hide");
                },
                 // Show Activity the dialog
                showActivityDialog = function () {
                    $("#dialog-activityDialog").modal("show");
                },
                // Hide Activity the dialog
                hideActivityDialog = function () {
                    $("#dialog-activityDialog").modal("hide");
                },
                  // Show Chauffer the dialog
                showChaufferDialog = function () {
                    $("#dialog-chaufferDialog").modal("show");
                },
                // Hide Chauffer the dialog
                hideChaufferDialog = function () {
                    $("#dialog-chaufferDialog").modal("hide");
                },
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        
                        return;
                    }

                    // Handle Sorting
                    //handleSorting("nRTTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getTariffType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel,
                showActivityDialog: showActivityDialog,
                hideActivityDialog: hideActivityDialog,
                showChaufferDialog: showChaufferDialog,
                hideChaufferDialog: hideChaufferDialog,
                show: show,
                hide: hide,
               
            };
        })(nRTViewModel);

        // Initialize the view model
        if (ist.nRT.view.bindingRoot) {
            nRTViewModel.initialize(ist.nRT.view);
        }
        return ist.nRT.view;
    });