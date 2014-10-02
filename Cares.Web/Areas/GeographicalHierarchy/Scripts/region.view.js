/*
    View for the Regions Used to keep the viewmodel clear of UI related logic
*/
define("region/region.view",
    ["jquery", "region/region.viewModel"], function ($, regionViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Region.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#RegionBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("RegionTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getRegions);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(regionViewModel);
        // Initialize the view model
        if (ist.Region.view.bindingRoot) {
            regionViewModel.initialize(ist.Region.view);
        }
        return ist.Region.view;
    });