/*
    Data service module with ajax calls to the server
*/
define("serviceRate/serviceRate.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Service Rate base 
                    amplify.request.define('getServiceRateBase', 'ajax', {
                        url: ist.siteUrl + '/Api/ServiceRtBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Service Rates 
                    amplify.request.define('getServiceRates', 'ajax', {
                        url: ist.siteUrl + '/Api/ServiceRt',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Service Rate detail
                    amplify.request.define('getServiceRateDetail', 'ajax', {
                        url: ist.siteUrl + '/Api/ServiceRtDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Service Rate
                    amplify.request.define('saveServiceRate', 'ajax', {
                        url: ist.siteUrl + '/Api/ServiceRt',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Service Rate
                    amplify.request.define('deleteServiceRate', 'ajax', {
                        url: ist.siteUrl + '/Api/ServiceRt',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Service Rate base
            getServiceRateBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceRateBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
              // Get Service Rate by id 
            getServiceRateDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceRateDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Service Rate
            saveServiceRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveServiceRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteServiceRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteServiceRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Service Rates 
            getServiceRates = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getServiceRates',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getServiceRateBase: getServiceRateBase,
            getServiceRates: getServiceRates,
            getServiceRateDetail: getServiceRateDetail,
            saveServiceRate: saveServiceRate,
            deleteServiceRate: deleteServiceRate
        };
    })();

    return dataService;
});