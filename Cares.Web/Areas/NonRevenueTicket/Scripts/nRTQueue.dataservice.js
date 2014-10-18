/*
    Data service module with ajax calls to the server
*/
define("nRTQueue/nRTQueue.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get NRT queue base Data
                    amplify.request.define('getNrtQueueBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/NrtQueueBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get NRT Mains 
                    amplify.request.define('getNrtMains', 'ajax', {
                        url: ist.siteUrl + '/Api/NrtQueue',
                        dataType: 'json',
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get NRT Queue base
            getNrtQueueBaseData = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getNrtQueueBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
        // Get NRT Mains
        getNrtMains = function (params, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getNrtMains',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        };

        return {
            getNrtQueueBaseData: getNrtQueueBaseData,
            getNrtMains: getNrtMains,
        };
    })();

    return dataService;
});