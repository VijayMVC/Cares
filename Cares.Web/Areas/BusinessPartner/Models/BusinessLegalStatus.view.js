/*
    View for the Business Legal Status Used to keep the viewmodel clear of UI related logic
*/
define("businessLegalStatus/businessLegalStatus.view",
    ["jquery", "businessLegalStatus/businessLegalStatus.viewModel"], function ($, businessLegalStatusViewModel) {
        var ist = window.ist || {};
        // View 
        ist.BusinessLegalStatus.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#BusinessLegalStatusBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getbusinessLegalStatuses);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessLegalStatusViewModel);
        // Initialize the view model
        if (ist.BusinessLegalStatus.view.bindingRoot) {
            businessLegalStatusViewModel.initialize(ist.BusinessLegalStatus.view);
        }
        return ist.BusinessLegalStatus.view;
    });