/*
    View for the Business Partner Relationship Type Used to keep the viewmodel clear of UI related logic
*/
define("relationType/relationType.view",
    ["jquery", "relationType/relationType.viewModel"], function ($, businessPartnerRelationshipTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.BusinessPartnerRelationshipType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#BusinessPartnerRelationshipTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("BusinessPartnerRelationshipTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getBusinessPartnerRelationshipTypes);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(businessPartnerRelationshipTypeViewModel);
        // Initialize the view model
        if (ist.BusinessPartnerRelationshipType.view.bindingRoot) {
            businessPartnerRelationshipTypeViewModel.initialize(ist.BusinessPartnerRelationshipType.view);
        }
        return ist.BusinessPartnerRelationshipType.view;
    });