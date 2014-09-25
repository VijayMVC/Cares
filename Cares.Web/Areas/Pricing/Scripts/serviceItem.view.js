/*
    View for the Service Item Used to keep the viewmodel clear of UI related logic
*/
define("serviceItem/serviceItem.view",
    ["jquery", "serviceItem/serviceItem.viewModel"], function ($, serviceItemViewModel) {
        var ist = window.ist || {};
        // View 
        ist.ServiceItem.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#ServiceItemBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("OrgGroupTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getServiceItems);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(serviceItemViewModel);
        // Initialize the view model
        if (ist.ServiceItem.view.bindingRoot) {
            serviceItemViewModel.initialize(ist.ServiceItem.view);
        }
        return ist.ServiceItem.view;
    });