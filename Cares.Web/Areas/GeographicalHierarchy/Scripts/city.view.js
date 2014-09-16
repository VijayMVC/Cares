/*
    View for the City Used to keep the viewmodel clear of UI related logic
*/
define("city/city.view",
    ["jquery", "city/city.viewModel"], function ($, cityViewModel) {
        var ist = window.ist || {};
        // View 
        ist.City.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#CityBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getCities);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(cityViewModel);
        // Initialize the view model
        if (ist.City.view.bindingRoot) {
            cityViewModel.initialize(ist.City.view);
        }
        return ist.City.view;
    });