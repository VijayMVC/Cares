/*
    View for the Tarrif Type. Used to keep the viewmodel clear of UI related logic
*/
define("tarrifType/tarrifType.view",
    ["jquery", "tarrifType/tarrifType.viewModel"], function ($, tarrifViewModel) {

        var ist = window.ist || {};

        // View 
        ist.tarrifType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#tarrifTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }

                    // Handle Sorting
                    handleSorting("tarrifTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getTarrifType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(tarrifViewModel);

        // Initialize the view model
        if (ist.tarrifType.view.bindingRoot) {
            tarrifViewModel.initialize(ist.tarrifType.view);
        }
        return ist.tarrifType.view;
    });