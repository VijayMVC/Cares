/*
    View for the Nrt Type Used to keep the viewmodel clear of UI related logic
*/
define("nRTType/nRTType.view",
    ["jquery", "nRTType/nRTType.viewModel"], function ($, nrtTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.NrtType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#NrtTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("NrtTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getNrtTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(nrtTypeViewModel);
        // Initialize the view model
        if (ist.NrtType.view.bindingRoot) {
            nrtTypeViewModel.initialize(ist.NrtType.view);
        }
        return ist.NrtType.view;
    });