/*
    Data service module with ajax calls to the server
*/
define("creditLimit/creditLimit.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {


                    // Define request to get Credit Limits 
                    amplify.request.define('getCreditLimits', 'ajax', {
                        url: ist.siteUrl + '/Api/CreditLimit',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Credit Limit
                    amplify.request.define('deleteCreditLimit', 'ajax', {
                        url: ist.siteUrl + '/Api/CreditLimit',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Credit Limit
                    amplify.request.define('saveCreditLimit', 'ajax', {
                        url: ist.siteUrl + '/Api/CreditLimit',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });

                    //Credit Limit base Data
                    amplify.request.define('getCreditLimitBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/CreditLimitBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    isInitialized = true;
                }
            },
            // Get Credit Limits
            getCreditLimits = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getCreditLimits',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Credit Limit.
            saveCreditLimit = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveCreditLimit',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Credit Limit.
            deleteCreditLimit = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteCreditLimit',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },


            //  Credit Limit Base Data
            getCreditLimitBaseData = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getCreditLimitBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
      
        return {
            getCreditLimitBaseData: getCreditLimitBaseData,
            saveCreditLimit: saveCreditLimit,
            getCreditLimits: getCreditLimits,
            deleteCreditLimit: deleteCreditLimit,

        };
    })();
    return dataService;
});