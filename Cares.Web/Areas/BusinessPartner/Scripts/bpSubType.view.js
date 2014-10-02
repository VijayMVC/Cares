/*
    View for the Business Partner Sub Types Used to keep the viewmodel clear of UI related logic
*/
define("bpSubType/bpSubType.view",
    ["jquery", "bpSubType/bpSubType.viewModel"], function ($, businessPartnerSubTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.BusinessPartnerSubType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#BusinessPartnerSubTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("BusinessPartnerSubTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getBusinessPartnerSubTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessPartnerSubTypeViewModel);
        // Initialize the view model
        if (ist.BusinessPartnerSubType.view.bindingRoot) {
            businessPartnerSubTypeViewModel.initialize(ist.BusinessPartnerSubType.view);
        }
        return ist.BusinessPartnerSubType.view;
    });