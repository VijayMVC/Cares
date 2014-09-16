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
                    //delete Workplace
                    amplify.request.define('deleteWorkplace', 'ajax', {
                        url: '/Api/Workplace',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    //delete Workplace
                    amplify.request.define('getWorkplaceOperations', 'ajax', {
                        url: '/Api/OperationsWorkPlace',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //update parent Workplace
                    amplify.request.define('updateParentWorkplace', 'ajax', {
                        url: '/Api/WorkPlace',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
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
            getWorkplaces = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'getWorkplaces',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //save Workplace
            saveWorkplace = function(params, callbacks) {
                debugger;

                return amplify.request({
                    resourceId: 'saveWorkplace',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Workplace
            deleteWorkplace = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteWorkplace',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

             //update Parent Workplace
            updateParentWorkplace = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'updateParentWorkplace',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //get workplace operations
            getWorkplaceOperations = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'getWorkplaceOperations',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getWorkplaceBaseData: getWorkplaceBaseData,
            getWorkplaces: getWorkplaces,
            saveWorkplace: saveWorkplace,
            deleteWorkplace: deleteWorkplace,
            getWorkplaceOperations: getWorkplaceOperations,
            updateParentWorkplace: updateParentWorkplace
        };
    })();
    return dataService;
});