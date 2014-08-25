/*
    Data service module with ajax calls to the server
*/
define("operation/operation.dataservice", function () {

    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {

                    
                    amplify.request.define('getOperationBaseData', 'ajax', {
                        url: '/Api/OperationBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    amplify.request.define('saveOperations', 'ajax', { 
                        url: '/Api/Operation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    amplify.request.define('getOperations', 'ajax', {
                        url: '/Api/Operation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    amplify.request.define('deleteOperation', 'ajax', {
                        url: '/Api/Operation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });

                    isInitialized = true;
                }
            },
            // Get Fleet Pool Base Data
            getOperationBaseData = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getOperationBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            getOperations = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getOperations',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            saveOperation = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'saveOperations',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            deleteOperation = function (params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'deleteOperation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };

        return {
            getOperationBaseData: getOperationBaseData,
            getOperations: getOperations,
            saveOperation:saveOperation,
            deleteOperation: deleteOperation
        };
    })();
    return dataService;
});