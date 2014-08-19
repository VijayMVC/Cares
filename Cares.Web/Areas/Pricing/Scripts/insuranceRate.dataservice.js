/*
    Data service module with ajax calls to the server
*/
define("insuranceRate/insuranceRate.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Insurance Rate base 
                    amplify.request.define('getInsuranceRateBase', 'ajax', {
                        url: '/Api/InsuranceRateBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Insurance Rate 
                    amplify.request.define('getInsuranceRate', 'ajax', {
                        url: '/Api/InsuranceRate',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Insurance Rate detail
                    amplify.request.define('getInsuranceRateDetail', 'ajax', {
                        url: '/Api/InsuranceRtDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Insurance Rate
                    amplify.request.define('saveInsuranceRate', 'ajax', {
                        url: '/Api/InsuranceRate',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Insurance Rate
                    amplify.request.define('deleteInsuranceRate', 'ajax', {
                        url: '/Api/InsuranceRate',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Insurance Rate base
            getInsuranceRateBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceRateBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
              // Get Insurance Rate by id 
            getInsuranceRateDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceRateDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Insurance Rate
            saveInsuranceRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveInsuranceRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteInsuranceRate = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteInsuranceRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Insurance Rates 
            getInsuranceRate = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getInsuranceRate',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getInsuranceRateBase: getInsuranceRateBase,
            getInsuranceRate: getInsuranceRate,
            getInsuranceRateDetail: getInsuranceRateDetail,
            saveInsuranceRate: saveInsuranceRate,
            deleteInsuranceRate: deleteInsuranceRate
        };
    })();

    return dataService;
});