/*
    View for the Documents Used to keep the viewmodel clear of UI related logic
*/
define("document/document.view",
    ["jquery", "document/document.viewModel"], function ($, documentViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Document.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#DocumentBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getDocuments);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(documentViewModel);
        // Initialize the view model
        if (ist.Document.view.bindingRoot) {
            documentViewModel.initialize(ist.Document.view);
        }
        return ist.Document.view;
    });