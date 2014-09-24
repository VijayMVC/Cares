/*
    Data service module with ajax calls to the server
*/
define("additionalCharge/additionalCharge.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Additional Charge base 
                    amplify.request.define('getAdditionalChargeBase', 'ajax', {
                        url: '/Api/AdditionalChargeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Additional Charges
                    amplify.request.define('getAdditionalCharges', 'ajax', {
                        url: '/Api/AdditionalCharge',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get  Additional Charge detail
                    amplify.request.define('getAdditionalChargeDetail', 'ajax', {
                        url: '/Api/AdditionalChargeDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save  Additional  Charges
                    amplify.request.define('saveAdditionalDriverCharge', 'ajax', {
                        url: '/Api/AdditionalCharge',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Additional Charges
                    amplify.request.define('deleteAdditionalDriverCharge', 'ajax', {
                        url: '/Api/AdditionalCharge',
                        dataType: 'json',
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Additional Charge Base
            getAdditionalChargeBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalChargeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
              // Get  Additional Charges by id 
            getAdditionalChargeDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalChargeDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Additional Charge
            saveAdditionalDriverCharge = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveAdditionalDriverCharge',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteAdditionalDriverCharge = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteAdditionalDriverCharge',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Addtional Charges
            getAdditionalCharges = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getAdditionalCharges',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getAdditionalChargeBase: getAdditionalChargeBase,
            getAdditionalCharges: getAdditionalCharges,
            saveAdditionalDriverCharge: saveAdditionalDriverCharge,
            deleteAdditionalDriverCharge: deleteAdditionalDriverCharge,
            getAdditionalChargeDetail: getAdditionalChargeDetail,

        };
    })();

    return dataService;
});