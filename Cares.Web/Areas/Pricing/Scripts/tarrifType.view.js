/*
    View for the tariff Type. Used to keep the viewmodel clear of UI related logic
*/
define("tariffType/tariffType.view",
    ["jquery", "tariffType/tariffType.viewModel"], function ($, tariffViewModel) {

        var ist = window.ist || {};

        // View 
        ist.tariffType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#tariffTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }

                    // Handle Sorting
                    handleSorting("tariffTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.gettariffType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(tariffViewModel);

        // Initialize the view model
        if (ist.tariffType.view.bindingRoot) {
            tariffViewModel.initialize(ist.tariffType.view);
        }
        return ist.tariffType.view;
    });