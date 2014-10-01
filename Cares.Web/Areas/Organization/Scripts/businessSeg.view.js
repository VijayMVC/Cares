/*
    View for the Business Segment. Used to keep the viewmodel clear of UI related logic
*/
define("businessSeg/businessSeg.view",
    ["jquery", "businessSeg/businessSeg.viewModel"], function ($, businessSegmentViewModel) {
        var ist = window.ist || {};
        // View 
        ist.BusinessSegment.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#BusinessSegmentBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("BusinessSegmentTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getBusinessSegment);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessSegmentViewModel);
        // Initialize the view model
        if (ist.BusinessSegment.view.bindingRoot) {
            businessSegmentViewModel.initialize(ist.BusinessSegment.view);
        }
        return ist.BusinessSegment.view;
    });