/*
    View for the Organization. Used to keep the viewmodel clear of UI related logic
*/
define("Organization/organizationGroup.view",
    ["jquery", "Organization/organizationGroup.viewModel"], function ($, organizationGroupViewModel) {
        var ist = window.ist || {};
        // View 
        ist.OrganizationGroup.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#OrgGroupBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getOrganizationGroups);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(organizationGroupViewModel);
        // Initialize the view model
        if (ist.OrganizationGroup.view.bindingRoot) {
            organizationGroupViewModel.initialize(ist.OrganizationGroup.view);
        }
        return ist.OrganizationGroup.view;
    });