/*
    View for the Product. Used to keep the viewmodel clear of UI related logic
*/
define("OrganizationGroup/OrganizationGroup.view",
    ["jquery", "OrganizationGroup/OrganizationGroup.viewModel"], function ($, organizationGroupViewModel) {

        var ist = window.ist || {};

        // View 
      
        ist.OrganizationGroup.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#OrgGroupRootBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                  //  handleSorting("OrganizationGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getFleetPools);
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