/*
    View for the Additional Charge. Used to keep the viewmodel clear of UI related logic
*/
define("additionalCharge/additionalCharge.view",
    ["jquery", "additionalCharge/additionalCharge.viewModel"], function ($, additionalChargeViewModel) {

        var ist = window.ist || {};

        // View 
        ist.additionalCharge.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#additionalChargeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("additionalChargeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getAdditionalCharges);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(additionalChargeViewModel);

        // Initialize the view model
        if (ist.additionalCharge.view.bindingRoot) {
            additionalChargeViewModel.initialize(ist.additionalCharge.view);
        }
        return ist.additionalCharge.view;
    });