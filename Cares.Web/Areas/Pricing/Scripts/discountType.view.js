/*
    View for the Discount Type Used to keep the viewmodel clear of UI related logic
*/
define("discountType/discountType.view",
    ["jquery", "discountType/discountType.viewModel"], function ($, DiscountTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.DiscountType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#DiscountTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("DiscountTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDiscountType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(DiscountTypeViewModel);
        // Initialize the view model
        if (ist.DiscountType.view.bindingRoot) {
            DiscountTypeViewModel.initialize(ist.DiscountType.view);
        }
        return ist.DiscountType.view;
    });