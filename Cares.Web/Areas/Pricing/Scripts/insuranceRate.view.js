/*
    View for the Insurance Rate. Used to keep the viewmodel clear of UI related logic
*/
define("insuranceRate/insuranceRate.view",
    ["jquery", "insuranceRate/insuranceRate.viewModel"], function ($, insuranceRateViewModel) {

        var ist = window.ist || {};

        // View 
        ist.insuranceRate.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#insuranceRateBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("insuranceRateTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getInsuranceRates);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(insuranceRateViewModel);

        // Initialize the view model
        if (ist.insuranceRate.view.bindingRoot) {
            insuranceRateViewModel.initialize(ist.insuranceRate.view);
        }
        return ist.insuranceRate.view;
    });