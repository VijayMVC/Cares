/*
    Data service module with ajax calls to the server
*/
define("marketingChannel/marketingChannel.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get Marketing Channels
                    amplify.request.define('getMarketingChannels', 'ajax', {
                        url: '/Api/MarketingChannel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Marketing Channel
                    amplify.request.define('deleteMarketingChannel', 'ajax', {
                        url: '/Api/MarketingChannel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Marketing Channel
                    amplify.request.define('saveMarketingChannel', 'ajax', {
                        url: '/Api/MarketingChannel',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Marketing Channels
            getMarketingChannels = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getMarketingChannels',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Marketing Channel
            saveMarketingChannel = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveMarketingChannel',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Marketing Channel
            deleteMarketingChannel = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteMarketingChannel',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveMarketingChannel: saveMarketingChannel,
            getMarketingChannels: getMarketingChannels,
            deleteMarketingChannel: deleteMarketingChannel,

        };
    })();
    return dataService;
});