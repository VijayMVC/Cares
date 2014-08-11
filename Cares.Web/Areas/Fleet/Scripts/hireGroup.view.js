/*
    View for the Hire Group. Used to keep the viewmodel clear of UI related logic
*/
define("hireGroup/hireGroup.view",
    ["jquery", "hireGroup/hireGroup.viewModel"], function ($, hireGroupViewModel) {

        var ist = window.ist || {};

        // View 
        ist.hireGroup.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#hireGroupBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("hireGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getTariffRates);

                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(hireGroupViewModel);

        // Initialize the view model
        if (ist.hireGroup.view.bindingRoot) {
            hireGroupViewModel.initialize(ist.hireGroup.view);
        }
        return ist.hireGroup.view;
    });