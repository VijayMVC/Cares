/*
    Data service module with ajax calls to the server
*/
define("workplace/workplace.dataservice", function () {
    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    //get Workplace Base Data
                    amplify.request.define('getWorkplaceBaseData', 'ajax', {
                        url: '/Api/WorkplaceBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //save Workplace
                    amplify.request.define('saveWorkplace', 'ajax', { 
                        url: '/Api/Workplace',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    //get Workplaces
                    amplify.request.define('getWorkplaces', 'ajax', {
                        url: '/Api/Workplace',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //delete Operation
                    amplify.request.define('deleteOperation', 'ajax', {
                        url: '/Api/Operation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    isInitialized = true;
                }
            },
            // Get Workplace Base Data
            getWorkplaceBaseData = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getWorkplaceBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //get Workplaces
            getWorkplaces = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getWorkplaces',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //save Workplace
            saveWorkplace = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'saveWorkplace',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Operation
            deleteOperation = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteOperation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getWorkplaceBaseData: getWorkplaceBaseData,
            getWorkplaces: getWorkplaces,
            saveWorkplace: saveWorkplace,
            deleteOperation: deleteOperation
        };
    })();
    return dataService;
});