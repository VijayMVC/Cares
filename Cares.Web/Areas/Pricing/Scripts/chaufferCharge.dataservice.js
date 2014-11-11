/*
    Data service module with ajax calls to the server
*/
define("chaufferCharge/chaufferCharge.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function () {
                if (!isInitialized) {

                    // Define request to get Chauffer Charge base 
                    amplify.request.define('getChaufferChargeBase', 'ajax', {
                        url: ist.siteUrl + '/Api/ChaufferChargeBase',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get Chauffer Charges
                    amplify.request.define('getChaufferCharges', 'ajax', {
                        url: ist.siteUrl + '/Api/ChaufferCharge',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to get  Chauffer Charge detail
                    amplify.request.define('getChaufferChargeDetail', 'ajax', {
                        url: ist.siteUrl + '/Api/ChaufferChargeDetail',
                        dataType: 'json',
                        type: 'GET'
                    });
                    // Define request to save  Chauffer  Charges
                    amplify.request.define('saveChaufferCharge', 'ajax', {
                        url: ist.siteUrl + '/Api/ChaufferCharge',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    // Define request to delete Chauffer Charges
                    amplify.request.define('deleteChaufferCharge', 'ajax', {
                        url: ist.siteUrl + '/Api/ChaufferCharge',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Chauffer Charge Base
            getChaufferChargeBase = function (callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getChaufferChargeBase',
                    success: callbacks.success,
                    error: callbacks.error,
                });
            },
              // Get  Chauffer Charges by id 
            getChaufferChargeDetail = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getChaufferChargeDetail',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
               // Save Chauffer Charge
            saveChaufferCharge = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveChaufferCharge',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
              // Delete
            deleteChaufferCharge = function (param, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteChaufferCharge',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: param
                });
            },
            // Get Chauffer Charges
            getChaufferCharges = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getChaufferCharges',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getChaufferChargeBase: getChaufferChargeBase,
            getChaufferCharges: getChaufferCharges,
            saveChaufferCharge: saveChaufferCharge,
            deleteChaufferCharge: deleteChaufferCharge,
            getChaufferChargeDetail: getChaufferChargeDetail,

        };
    })();

    return dataService;
});