/*
    View for the Regions Used to keep the viewmodel clear of UI related logic
*/
define("area/area.view",
    ["jquery", "area/area.viewModel"], function ($, areaViewModel) {
        var ist = window.ist || {};
        // View 
        ist.Area.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#AreaBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getArea);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(areaViewModel);
        // Initialize the view model
        if (ist.Area.view.bindingRoot) {
            areaViewModel.initialize(ist.Area.view);
        }
        return ist.Area.view;
    });