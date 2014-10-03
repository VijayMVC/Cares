/*
    View for the Credit Limit Used to keep the viewmodel clear of UI related logic
*/
define("creditLimit/creditLimit.view",
    ["jquery", "creditLimit/creditLimit.viewModel"], function ($, creditLimitViewModel) {
        var ist = window.ist || {};
        // View 
        ist.CreditLimit.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#CreditLimitBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("CreditLimitTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getCreditLimits);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(creditLimitViewModel);
        // Initialize the view model
        if (ist.CreditLimit.view.bindingRoot) {
            creditLimitViewModel.initialize(ist.CreditLimit.view);
        }
        return ist.CreditLimit.view;
    });