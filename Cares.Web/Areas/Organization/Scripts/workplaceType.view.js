/*
    View for the workplaceType. Used to keep the viewmodel clear of UI related logic
*/
define("workplaceType/workplaceType.view",
    ["jquery", "workplaceType/workplaceType.viewModel"], function ($, workplacetypeGroupViewModel) {
        var ist = window.ist || {};
        // View 
        ist.WorkPlaceType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#WorkPlaceTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getWorkPlaceType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(workplacetypeGroupViewModel);
        // Initialize the view model
        if (ist.WorkPlaceType.view.bindingRoot) {
            workplacetypeGroupViewModel.initialize(ist.WorkPlaceType.view);
        }
        return ist.WorkPlaceType.view;
    });