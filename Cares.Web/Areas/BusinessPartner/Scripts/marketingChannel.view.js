/*
    View for the Marketing Channels Used to keep the viewmodel clear of UI related logic
*/
define("marketingChannel/marketingChannel.view",
    ["jquery", "marketingChannel/marketingChannel.viewModel"], function ($, marketingChannelnViewModel) {
        var ist = window.ist || {};
        // View 
        ist.MarketingChannel.view = (function (specifiedViewModel) {
            var
                // View model 
                viewModel = specifiedViewModel,
                // Binding root used with knockout
                bindingRoot = $("#MarketingChannelBinding")[0],
                // Initialize
                initialize = function () {
                    if (!bindingRoot) {
                        return;
                    }
                    // Handle Sorting
                    handleSorting("MarketingChannelTable", viewModel.sortOn, viewModel.sortIsAsc, viewModel.getMarketingChannels);
                };
            initialize();
            return {
                bindingRoot: bindingRoot,
                viewModel: viewModel
            };
        })(marketingChannelnViewModel);
        // Initialize the view model
        if (ist.MarketingChannel.view.bindingRoot) {
            marketingChannelnViewModel.initialize(ist.MarketingChannel.view);
        }
        return ist.MarketingChannel.view;
    });