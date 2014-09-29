/*
    View for the Seasonal Discount. Used to keep the viewmodel clear of UI related logic
*/
define("seasonalDiscount/seasonalDiscount.view",
    ["jquery", "seasonalDiscount/seasonalDiscount.viewModel"], function ($, seasonalDiscountViewModel) {

        var ist = window.ist || {};

        // View 
        ist.seasonalDiscount.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#seasonalDiscountBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("seasonalDiscountTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getSeasonalDiscounts);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(seasonalDiscountViewModel);

        // Initialize the view model
        if (ist.seasonalDiscount.view.bindingRoot) {
            seasonalDiscountViewModel.initialize(ist.seasonalDiscount.view);
        }
        return ist.seasonalDiscount.view;
    });