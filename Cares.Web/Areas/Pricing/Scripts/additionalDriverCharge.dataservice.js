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
                    // Define request to get  Additional Driver Charge detail
                    amplify.request.define('getAdditionalDriverChrgDetail', 'ajax', {
                        url: '/Api/AdditionalDriverChargeDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save  Additional Driver Charges
                    amplify.request.define('saveAdditionalDriverChrg', 'ajax', {
                        url: '/Api/AdditionalDriverCharge',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Additional Driver Charges
                    amplify.request.define('deleteAdditionalDriverChrg', 'ajax', {
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
              // Get  Additional Driver Charges by id 
            getAdditionalDriverChrgDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalDriverChrgDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Additional Driver Charge
            saveAdditionalDriverChrg = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveAdditionalDriverChrg',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteAdditionalDriverChrg = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteAdditionalDriverChrg',
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
            getAddDriverChrgs: getAddDriverChrgs,
            saveAdditionalDriverChrg: saveAdditionalDriverChrg,
            getAdditionalDriverChrgDetail: getAdditionalDriverChrgDetail,
            deleteAdditionalDriverChrg: deleteAdditionalDriverChrg,
            
        };
    })();

    return dataService;
});