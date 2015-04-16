/*
    View for the RA Queue. Used to keep the viewmodel clear of UI related logic
*/
define("raQueue/raQueue.view",
    ["jquery", "raQueue/raQueue.viewModel"], function ($, raQueueViewModel) {

        var ist = window.ist || {};

        // View 
        ist.raQueue.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#raQueueBinding")[0],
                // Goto Rental Agreement
                gotoRentalAgreement = function (raMainId) {
                    openUrlInNewWindow(ist.siteUrl + "/RentalAgreement/Home/Index/#/byId/" + raMainId);
                },
                // Open url in new window
                openUrlInNewWindow = function (url) {
                    window.open(url, "_blank");
                },
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("raQueueTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getRaMains);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel,
                gotoRentalAgreement: gotoRentalAgreement
            };
        })(raQueueViewModel);

        // Initialize the view model
        if (ist.raQueue.view.bindingRoot) {
            raQueueViewModel.initialize(ist.raQueue.view);
        }
        return ist.raQueue.view;
    });