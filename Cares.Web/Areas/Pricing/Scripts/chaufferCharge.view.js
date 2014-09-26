/*
    View for the Chauffer Charge. Used to keep the viewmodel clear of UI related logic
*/
define("chaufferCharge/chaufferCharge.view",
    ["jquery", "chaufferCharge/chaufferCharge.viewModel"], function ($, chaufferChargeViewModel) {

        var ist = window.ist || {};

        // View 
        ist.chaufferCharge.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#chaufferChargeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("chaufferChargeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getChaufferCharges);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(chaufferChargeViewModel);

        // Initialize the view model
        if (ist.chaufferCharge.view.bindingRoot) {
            chaufferChargeViewModel.initialize(ist.chaufferCharge.view);
        }
        return ist.chaufferCharge.view;
    });