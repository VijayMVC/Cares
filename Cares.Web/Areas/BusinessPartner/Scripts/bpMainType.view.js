/*
    View for the Business Partner Main type Used to keep the viewmodel clear of UI related logic
*/
define("bpMainType/bpMainType.view",
    ["jquery", "bpMainType/bpMainType.viewModel"], function ($, businessPartnerViewModel) {
        var ist = window.ist || {};
        // View 
        ist.BusinessPartnerMainType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#bPMainTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getBusinessPartnerMainTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessPartnerViewModel);
        // Initialize the view model
        if (ist.BusinessPartnerMainType.view.bindingRoot) {
            businessPartnerViewModel.initialize(ist.BusinessPartnerMainType.view);
        }
        return ist.BusinessPartnerMainType.view;
    });