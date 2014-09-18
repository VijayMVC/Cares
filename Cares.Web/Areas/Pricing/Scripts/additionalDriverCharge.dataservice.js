/*
    Data service module with ajax calls to the server
*/
define("additionalDriverCharge/additionalDriverCharge.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Additional Driver Charge base 
                    amplify.request.define('getAdditionalDriverChrgBase', 'ajax', {
                        url: '/Api/AdditionalDriverChargeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Additional Driver Charges
                    amplify.request.define('getAddDriverChrgs', 'ajax', {
                        url: '/Api/AdditionalDriverCharge',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Service Rate detail
                    amplify.request.define('getServiceRateDetail', 'ajax', {
                        url: '/Api/AdditionalDriverCharge',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save Service Rate
                    amplify.request.define('saveServiceRate', 'ajax', {
                        url: '/Api/AdditionalDriverCharge',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Service Rate
                    amplify.request.define('deleteServiceRate', 'ajax', {
                        url: '/Api/AdditionalDriverCharge',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Additional Driver Chrg Base
            getAdditionalDriverChrgBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalDriverChrgBase',
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
            // Get Addtional Driver Charges
            getAddDriverChrgs = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAddDriverChrgs',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getAdditionalDriverChrgBase: getAdditionalDriverChrgBase,
            getAddDriverChrgs: getAddDriverChrgs
            
        };
    })();

    return dataService;
});