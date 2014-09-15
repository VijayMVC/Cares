/*
    View for the Sub Regions Used to keep the viewmodel clear of UI related logic
*/
define("subRegion/subRegion.view",
    ["jquery", "subRegion/subRegion.viewModel"], function ($, subRegionViewModel) {
        var ist = window.ist || {};
        // View 
        ist.SubRegion.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#SubRegionBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getSubRegions);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(subRegionViewModel);
        // Initialize the view model
        if (ist.SubRegion.view.bindingRoot) {
            subRegionViewModel.initialize(ist.SubRegion.view);
        }
        return ist.SubRegion.view;
    });