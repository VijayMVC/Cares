/*
    View for the Service Type Used to keep the viewmodel clear of UI related logic
*/
define("serviceType/serviceType.view",
    ["jquery", "serviceType/serviceType.viewModel"], function ($, serviceTypeViewModel) {
        var ist = window.ist || {};
        // View 
        ist.ServiceType.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#ServiceTypeBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("ServiceTypeTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getServiceType);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(serviceTypeViewModel);
        // Initialize the view model
        if (ist.ServiceType.view.bindingRoot) {
            serviceTypeViewModel.initialize(ist.ServiceType.view);
        }
        return ist.ServiceType.view;
    });