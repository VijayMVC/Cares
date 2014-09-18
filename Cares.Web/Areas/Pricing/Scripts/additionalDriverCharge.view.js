/*
    View for the Additional Driver Charge. Used to keep the viewmodel clear of UI related logic
*/
define("additionalDriverCharge/additionalDriverCharge.view",
    ["jquery", "additionalDriverCharge/additionalDriverCharge.viewModel"], function ($, additionalDriverChargeViewModel) {

        var ist = window.ist || {};

        // View 
        ist.additionalDriverCharge.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#additionalDriverChargeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("additionalDriverChargeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getAddDriverChrgs);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(additionalDriverChargeViewModel);

        // Initialize the view model
        if (ist.additionalDriverCharge.view.bindingRoot) {
            additionalDriverChargeViewModel.initialize(ist.additionalDriverCharge.view);
        }
        return ist.additionalDriverCharge.view;
    });