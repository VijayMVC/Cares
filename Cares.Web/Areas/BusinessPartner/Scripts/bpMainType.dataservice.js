/*
    Data service module with ajax calls to the server
*/
define("bpMainType/bpMainType.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    // Define request to get save Bp MainTypes
                    amplify.request.define('getBpMainTypes', 'ajax', {
                        url: '/Api/BpMainType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    // Define request to delete Bp Main Type
                    amplify.request.define('deleteBpMainType', 'ajax', {
                        url: '/Api/BpMainType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    // Define request to add/update Bp Main Type
                    amplify.request.define('saveBpMainType', 'ajax', {
                        url: '/Api/BpMainType',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    isInitialized = true;
                }
            },
            // Get Bp Main Types
            getBpMainTypes = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getBpMainTypes',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //add-update Bp Main Types
            saveBpMainType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveBpMainType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Bp Main Types
            deleteBpMainType = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteBpMainType',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            saveBpMainType: saveBpMainType,
            getBpMainTypes: getBpMainTypes,
            deleteBpMainType: deleteBpMainType,

        };
    })();
    return dataService;
});