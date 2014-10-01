/*
    View for the Documents Used to keep the viewmodel clear of UI related logic
*/
define("ratingType/ratingType.view",
    ["jquery", "ratingType/ratingType.viewModel"], function ($, ratingTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.RatingType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#RatingTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getRatingTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(ratingTypeViewModel);
        // Initialize the view model
        if (ist.RatingType.view.bindingRoot) {
            ratingTypeViewModel.initialize(ist.RatingType.view);
        }
        return ist.RatingType.view;
    });