/*
    View for the Document Groups Used to keep the viewmodel clear of UI related logic
*/
define("documentGroup/documentGroup.view",
    ["jquery", "documentGroup/documentGroup.viewModel"], function ($, documentGroupViewModel) {
        var ist = window.ist || {};
        // View 
        ist.DocumentGroup.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#documentGroupBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("documentGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDocumentGroups);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(documentGroupViewModel);
        // Initialize the view model
        if (ist.DocumentGroup.view.bindingRoot) {
            documentGroupViewModel.initialize(ist.DocumentGroup.view);
        }
        return ist.DocumentGroup.view;
    });