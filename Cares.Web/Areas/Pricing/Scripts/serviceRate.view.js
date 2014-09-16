/*
    View for the Service Rate. Used to keep the viewmodel clear of UI related logic
*/
define("serviceRate/serviceRate.view",
    ["jquery", "serviceRate/serviceRate.viewModel"], function ($, serviceRateViewModel) {

        var ist = window.ist || {};

        // View 
        ist.serviceRate.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#serviceRateBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("serviceRateTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getServiceRates);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(serviceRateViewModel);

        // Initialize the view model
        if (ist.serviceRate.view.bindingRoot) {
            serviceRateViewModel.initialize(ist.serviceRate.view);
        }
        return ist.serviceRate.view;
    });