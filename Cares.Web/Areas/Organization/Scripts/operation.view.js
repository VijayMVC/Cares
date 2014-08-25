/*
    View for the Product. Used to keep the viewmodel clear of UI related logic
*/
define("operation/operation.view",
    ["jquery", "operation/operation.viewModel"], function ($, operationViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Operation.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#OperationBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OperationsTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getOperations);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(operationViewModel);
        // Initialize the view model
        if (ist.Operation.view.bindingRoot) {
            operationViewModel.initialize(ist.Operation.view);
        }
        return ist.Operation.view;
    });