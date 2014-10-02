/*
    View for the Discount Sub Types Used to keep the viewmodel clear of UI related logic
*/
define("discountSubType/discountSubType.view",
    ["jquery", "discountSubType/discountSubType.viewModel"], function ($, discountSubTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.DiscountSubType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#DiscountSubTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("DiscountSubTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDiscountSubTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(discountSubTypeViewModel);
        // Initialize the view model
        if (ist.DiscountSubType.view.bindingRoot) {
            discountSubTypeViewModel.initialize(ist.DiscountSubType.view);
        }
        return ist.DiscountSubType.view;
    });