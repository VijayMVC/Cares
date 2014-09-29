/*
    Data service module with ajax calls to the server
*/
define("workLocation/workLocation.dataservice", function () {
    // Data service for forecast 
    var dataService = (function () {
        var
            // True if initialized
            isInitialized = false,
            // Initialize
            initialize = function() {
                if (!isInitialized) {
                    //get Work Location BaseData
                    amplify.request.define('getWorkLocationBaseData', 'ajax', {
                        url: ist.siteUrl + '/Api/WorkLocationBase',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });

                    //save Work Location
                    amplify.request.define('saveWorkLocation', 'ajax', {
                        url: ist.siteUrl + '/Api/WorkLocation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'POST'
                    });
                    //get Work Locations
                    amplify.request.define('getWorkLocations', 'ajax', {
                        url: ist.siteUrl + '/Api/WorkLocation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                    //delete Workplace
                    amplify.request.define('deleteWorkLocation', 'ajax', {
                        url: ist.siteUrl + '/Api/WorkLocation',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'DELETE'
                    });
                    //delete Workplace
                    amplify.request.define('getWorkLocationPhones', 'ajax', {
                        url: ist.siteUrl + '/Api/Phone',
                        dataType: 'json',
                        decoder: amplify.request.decoders.istStatusDecoder,
                        type: 'GET'
                    });
                   
                    isInitialized = true;
                }
            },
            // Get Worklocation Base Data
            getWorkLocationBaseData = function(params, callbacks) {
                initialize();
                return amplify.request({
                    resourceId: 'getWorkLocationBaseData',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //get Work Locations
            getWorkLocations = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'getWorkLocations',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //save Workplace
            saveWorkLocation = function (params, callbacks) {
                debugger;
                return amplify.request({
                    resourceId: 'saveWorkLocation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },
            //delete Work Location
            deleteWorkLocation = function(params, callbacks) {
                return amplify.request({
                    resourceId: 'deleteWorkLocation',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            },

        
            //get workplace operations
            getWorkLocationPhones = function (params, callbacks) {
                return amplify.request({
                    resourceId: 'getWorkLocationPhones',
                    success: callbacks.success,
                    error: callbacks.error,
                    data: params
                });
            };
        return {
            getWorkLocationBaseData: getWorkLocationBaseData,
            getWorkLocations: getWorkLocations,
            saveWorkLocation: saveWorkLocation,
            deleteWorkLocation: deleteWorkLocation,
            getWorkLocationPhones: getWorkLocationPhones,
        };
    })();
    return dataService;
});