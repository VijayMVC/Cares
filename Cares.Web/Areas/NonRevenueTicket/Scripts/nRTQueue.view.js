/*
    View for the NRT Queue. Used to keep the viewmodel clear of UI related logic
*/
define("nRTQueue/nRTQueue.view",
// ReSharper disable once InconsistentNaming
    ["jquery", "nRTQueue/nRTQueue.viewModel"], function ($, nRTQueueViewModel) {

        var ist = window.ist || {};

        // View 
        ist.nRTQueue.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#nRTQueueBinding")[0],
                // Goto NRT
                gotoNrt = function (nrtMainId) {
                    openUrlInNewWindow("/NonRevenueTicket/NonRevenueTicket/Index/#/byId/" + nrtMainId);
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
                    handleSorting("nRTQueueTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getNrtMains);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel,
                gotoNrt: gotoNrt
            };
        })(nRTQueueViewModel);

        // Initialize the view model
        if (ist.nRTQueue.view.bindingRoot) {
            nRTQueueViewModel.initialize(ist.nRTQueue.view);
        }
        return ist.nRTQueue.view;
    });