/*
    View for the Tariff Rate. Used to keep the viewmodel clear of UI related logic
*/
define("tariffRate/tariffRate.view",
    ["jquery", "tariffRate/tariffRate.viewModel"], function ($, tariffViewModel) {

        var ist = window.ist || {};

        // View 
        ist.tariffRate.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#tariffRateBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("tariffRateTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getTariffRates);

                    // Handle Sorting
                    handleSorting("hireGroupRate", viewModel.sortOnHg, viewModel.sortIsAscHg, viewModel.getHireGroupDetails);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(tariffViewModel);

        // Initialize the view model
        if (ist.tariffRate.view.bindingRoot) {
            tariffViewModel.initialize(ist.tariffRate.view);
        }
        return ist.tariffRate.view;
    });