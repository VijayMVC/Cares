/*
    Data service module with ajax calls to the server
*/
define("raQueue/raQueue.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get RA queue base Data
                    amplify.request.define('getRaQueueBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/RaQueueBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get RA Mains 
                    amplify.request.define('getRaMains', 'ajax', {
                        url: ist.siteUrl + '/Api/RaQueue',
                        dataType: 'json',
                        type: 'GET'
                    });
                    
                    isInitialized = true;
                }
            },
            // Get Insurance Rate base
            getRaQueueBaseData = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getRaQueueBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
        // Get RA Mains
        getRaMains = function (params, callbacks) {
            initialize();
            return amplify.request({
                resourceId: 'getRaMains',
                success: callbacks.success,
                error: callbacks.error,
                data: params
            });
        };

        return {
            getRaQueueBaseData: getRaQueueBaseData,
            getRaMains: getRaMains,
        };
    })();

    return dataService;
});